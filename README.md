backup-profile (pre-alpha)
==========================
Small utility to securely back up user profiles on a whole in Windows Vista, 7, 8. Its a stand alone utility that requirs no installation. It will only run from an external storage ensuring that the profile is backed up on something other than the physical hard disk. 


Usage
=====
* A user profile is selected from the available list
* User selecti are made: zipped file? time stamped? password protec?
* It then automatically copies that select user profile onto the external drive using [volume shadow copying] (http://en.wikipedia.org/wiki/Shadow_Copy "Shadow Copy")
* An alert whether the process is successful or not will appear


Todo
====
- [ ] Project name subject to change after beta release
- [ ] Everything :) This is just the skeleton frame and skeleton functions for progress bar, copy, zip, timestamp, drive recognition, etc


Contributors
============
* [Ashton Paul](https://github.com/ashtonp "ashtonp")
* [Akeem Wilson](https://github.com/akeemwil "akeemwil")
