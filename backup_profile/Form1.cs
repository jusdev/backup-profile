using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.Threading;



namespace backup_profile
{
    public delegate void ProgressChangeDelegate(double Persentage, ref bool Cancel);
    public delegate void Completedelegate();
    
 

    public partial class backup_profile : Form
    {
        public string systemDrivePath;
        public string currentDrivePath;
        public string VolumeName;
        public string username;
        public int fileprogress = 0;
        public int backupChoice = 0;
        public int progressMax = 0;
        
        delegate void SetProgressBarCallBack(int value);
        private Thread demoThread = null;

        protected virtual bool IsFileLocked(string file)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public backup_profile()
        {
            InitializeComponent();

            var pos = this.PointToScreen(filename.Location);
            pos = filename.PointToClient(pos);

            filename.Text    = "";
            backupType.Items.Insert(0,"Full");
            backupType.Items.Insert(1, "Incremental");
            backupType.SelectedIndex = 0;
            backupType.DropDownStyle = ComboBoxStyle.DropDownList;

            systemDrivePath  = Environment.GetEnvironmentVariable("SystemDrive") + "\\";
            currentDrivePath = Path.GetPathRoot(Application.ExecutablePath).ToString();
            username         = Environment.GetEnvironmentVariable("UserName");

            DriveInfo[] theDrives = DriveInfo.GetDrives();
            foreach (DriveInfo Drive in theDrives)
            {
                if (Drive.RootDirectory.ToString().Equals(currentDrivePath))
                {
                    cur_drive.Text = currentDrivePath + Drive.VolumeLabel.Replace("\\", "");
                    cur_drive.Text = Drive.VolumeLabel.Replace("\\", "") + " - " + currentDrivePath + " [Free Space: " + Math.Round(Drive.TotalFreeSpace / 1073741824.00, 2).ToString() + " GB]";
                }

                if (Drive.RootDirectory.ToString().Equals(systemDrivePath))
                {
                    source_path.Text = systemDrivePath + "Users\\" + username;
                    dest_path.Text   = currentDrivePath + "_backups\\";
                }
            }
            
            cur_user.Text = username;
        }

        private void StartCopy()
        {
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copy_button_Click(object sender, EventArgs e)
        {
            backupChoice = backupType.SelectedIndex;
            copy_button.Enabled = false;
            this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));
            this.demoThread.Start();
            StartCopy();
        }

        private void ThreadProcSafe()
		{
			this.SetProgress(progressMax);
		}

        private void SetProgress(int value)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (this.progressBar.InvokeRequired)
			{	
				SetProgressBarCallBack d = new SetProgressBarCallBack(SetProgress);
				this.Invoke(d, new object[] { value });
			}
			else
			{
				this.progressBar.Maximum = value;
			}
		}

        private void backgroundWorker_DoWork_1(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            string zipName = username.Replace(" ", "") + rnd.Next(10000, 99999) + '-' + System.DateTime.Today.ToShortDateString().Replace("/", "");
            string SourcePath = systemDrivePath + "Users\\" + username + "\\Desktop\\copy";
            string DestinationPath = currentDrivePath + "_backups\\" + zipName;

            CustomFileCopier copy_file = new CustomFileCopier("", "");

            string[] files = Directory.GetFiles(SourcePath, "*.*", SearchOption.AllDirectories);
            progressMax = files.Count();
            fileprogress = 0;
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            bool copyFlag;
            //Copy all the files
            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
            {
                copyFlag = false;
                if (backupChoice == 0)
                {
                    copyFlag = true;
                }
                else
                {
                }

                if (copyFlag)
                {
                    // filename.Text = newPath; 
                    copy_file.SourceFilePath = newPath;
                    copy_file.DestFilePath = newPath.Replace(SourcePath, DestinationPath);
                    if (!(IsFileLocked(newPath)))
                    {
                        copy_file.Copy();
                    }
                    else
                    {
                        //Volume Shadow Copy Here
                    }
                    fileprogress++;
                    backgroundWorker.ReportProgress(fileprogress, newPath);
                }
            }

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(DestinationPath);
                zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
                zip.Save(DestinationPath + ".zip");
            }

            System.IO.DirectoryInfo backup_cache = new DirectoryInfo(DestinationPath);

            foreach (FileInfo file in backup_cache.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in backup_cache.GetDirectories())
            {
                dir.Delete(true);
            }
            Directory.Delete(DestinationPath);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            filename.Text = e.UserState.ToString().Replace(systemDrivePath + "Users\\" + username, "");
            progressBar.Maximum = progressMax;
            progressBar.Value = fileprogress;
            progressBar.Update();
        }
     
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cancel_button.Text = "Close";
            filename.Text = "";
            MessageBox.Show("Backup Complete");
        }


    }

    class CustomFileCopier
    {
        public CustomFileCopier(string Source, string Dest)
        {
            this.SourceFilePath = Source;
            this.DestFilePath = Dest;

            OnProgressChanged += delegate { };
            OnComplete += delegate { };
        }

        public void Copy()
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
            bool cancelFlag = false;

            using (FileStream source = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read))
            {
                long fileLength = source.Length;
                if (File.Exists(DestFilePath))
                {
                    File.Delete(DestFilePath);
                }

                using (FileStream dest = new FileStream(DestFilePath, FileMode.CreateNew, FileAccess.Write))
                {
                    long totalBytes = 0;
                    int currentBlockSize = 0;

                    while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytes += currentBlockSize;
                        double persentage = (double)totalBytes * 100.0 / fileLength;

                        dest.Write(buffer, 0, currentBlockSize);

                        cancelFlag = false;
                        OnProgressChanged(persentage, ref cancelFlag);

                        if (cancelFlag == true)
                        {
                            // Delete dest file here
                            break;
                        }
                    }
                }
            }

            OnComplete();
        }

        public string SourceFilePath { get; set; }
        public string DestFilePath { get; set; }

        public event ProgressChangeDelegate OnProgressChanged;
        public event Completedelegate OnComplete;
    }

}

