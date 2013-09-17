namespace backup_profile
{
    partial class backup_profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cur_drive_label = new System.Windows.Forms.Label();
            this.cur_user_label = new System.Windows.Forms.Label();
            this.cur_user = new System.Windows.Forms.TextBox();
            this.cur_drive = new System.Windows.Forms.TextBox();
            this.source_path_label = new System.Windows.Forms.Label();
            this.source_path = new System.Windows.Forms.TextBox();
            this.copy_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.dest_path_label = new System.Windows.Forms.Label();
            this.dest_path = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.filename = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backupType = new System.Windows.Forms.ComboBox();
            this.backupTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cur_drive_label
            // 
            this.cur_drive_label.AutoSize = true;
            this.cur_drive_label.Location = new System.Drawing.Point(20, 26);
            this.cur_drive_label.Name = "cur_drive_label";
            this.cur_drive_label.Size = new System.Drawing.Size(72, 13);
            this.cur_drive_label.TabIndex = 0;
            this.cur_drive_label.Text = "Current Drive:";
            // 
            // cur_user_label
            // 
            this.cur_user_label.AutoSize = true;
            this.cur_user_label.Location = new System.Drawing.Point(20, 49);
            this.cur_user_label.Name = "cur_user_label";
            this.cur_user_label.Size = new System.Drawing.Size(69, 13);
            this.cur_user_label.TabIndex = 3;
            this.cur_user_label.Text = "Current User:";
            // 
            // cur_user
            // 
            this.cur_user.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cur_user.Location = new System.Drawing.Point(114, 49);
            this.cur_user.Name = "cur_user";
            this.cur_user.ReadOnly = true;
            this.cur_user.Size = new System.Drawing.Size(403, 20);
            this.cur_user.TabIndex = 4;
            // 
            // cur_drive
            // 
            this.cur_drive.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cur_drive.Location = new System.Drawing.Point(114, 23);
            this.cur_drive.Name = "cur_drive";
            this.cur_drive.ReadOnly = true;
            this.cur_drive.Size = new System.Drawing.Size(403, 20);
            this.cur_drive.TabIndex = 5;
            // 
            // source_path_label
            // 
            this.source_path_label.AutoSize = true;
            this.source_path_label.Location = new System.Drawing.Point(20, 82);
            this.source_path_label.Name = "source_path_label";
            this.source_path_label.Size = new System.Drawing.Size(69, 13);
            this.source_path_label.TabIndex = 6;
            this.source_path_label.Text = "Source Path:";
            // 
            // source_path
            // 
            this.source_path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.source_path.Location = new System.Drawing.Point(114, 75);
            this.source_path.Name = "source_path";
            this.source_path.ReadOnly = true;
            this.source_path.Size = new System.Drawing.Size(403, 20);
            this.source_path.TabIndex = 7;
            // 
            // copy_button
            // 
            this.copy_button.Location = new System.Drawing.Point(114, 252);
            this.copy_button.Name = "copy_button";
            this.copy_button.Size = new System.Drawing.Size(75, 23);
            this.copy_button.TabIndex = 8;
            this.copy_button.Text = "Copy";
            this.copy_button.UseVisualStyleBackColor = true;
            this.copy_button.Click += new System.EventHandler(this.copy_button_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(195, 252);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 9;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // dest_path_label
            // 
            this.dest_path_label.AutoSize = true;
            this.dest_path_label.Location = new System.Drawing.Point(20, 104);
            this.dest_path_label.Name = "dest_path_label";
            this.dest_path_label.Size = new System.Drawing.Size(88, 13);
            this.dest_path_label.TabIndex = 11;
            this.dest_path_label.Text = "Destination Path:";
            // 
            // dest_path
            // 
            this.dest_path.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dest_path.Location = new System.Drawing.Point(114, 101);
            this.dest_path.Name = "dest_path";
            this.dest_path.ReadOnly = true;
            this.dest_path.Size = new System.Drawing.Size(403, 20);
            this.dest_path.TabIndex = 12;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(114, 154);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(403, 23);
            this.progressBar.TabIndex = 13;
            // 
            // filename
            // 
            this.filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.filename.AutoSize = true;
            this.filename.BackColor = System.Drawing.Color.Transparent;
            this.filename.Location = new System.Drawing.Point(114, 183);
            this.filename.Margin = new System.Windows.Forms.Padding(3);
            this.filename.MaximumSize = new System.Drawing.Size(403, 23);
            this.filename.MinimumSize = new System.Drawing.Size(403, 23);
            this.filename.Name = "filename";
            this.filename.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.filename.Size = new System.Drawing.Size(403, 23);
            this.filename.TabIndex = 10;
            this.filename.Text = "filename";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork_1);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // backupType
            // 
            this.backupType.FormattingEnabled = true;
            this.backupType.Location = new System.Drawing.Point(114, 127);
            this.backupType.Name = "backupType";
            this.backupType.Size = new System.Drawing.Size(121, 21);
            this.backupType.TabIndex = 16;
            // 
            // backupTypeLabel
            // 
            this.backupTypeLabel.AutoSize = true;
            this.backupTypeLabel.Location = new System.Drawing.Point(20, 130);
            this.backupTypeLabel.Name = "backupTypeLabel";
            this.backupTypeLabel.Size = new System.Drawing.Size(74, 13);
            this.backupTypeLabel.TabIndex = 17;
            this.backupTypeLabel.Text = "Backup Type:";
            // 
            // backup_profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 287);
            this.Controls.Add(this.backupTypeLabel);
            this.Controls.Add(this.backupType);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.dest_path);
            this.Controls.Add(this.dest_path_label);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.copy_button);
            this.Controls.Add(this.source_path);
            this.Controls.Add(this.source_path_label);
            this.Controls.Add(this.cur_drive);
            this.Controls.Add(this.cur_user);
            this.Controls.Add(this.cur_user_label);
            this.Controls.Add(this.cur_drive_label);
            this.Name = "backup_profile";
            this.Text = "ShadowBackup - By Ashton Paul";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cur_drive_label;
        private System.Windows.Forms.Label cur_user_label;
        private System.Windows.Forms.TextBox cur_user;
        private System.Windows.Forms.TextBox cur_drive;
        private System.Windows.Forms.Label source_path_label;
        private System.Windows.Forms.TextBox source_path;
        private System.Windows.Forms.Button copy_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Label dest_path_label;
        private System.Windows.Forms.TextBox dest_path;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label filename;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ComboBox backupType;
        private System.Windows.Forms.Label backupTypeLabel;
    }
}

