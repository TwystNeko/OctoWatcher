using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Temp.IO;

namespace OctoWatcher
{


    public partial class mainForm : Form
    {
        MyFileSystemWatcher fsWatcher = new MyFileSystemWatcher();
        public mainForm()
        {
            InitializeComponent();
            watchFolder.Text = Properties.Settings.Default.watchFolder;
            octoPrintAddress.Text = Properties.Settings.Default.octoPrintAddress;
            apiKey.Text = Properties.Settings.Default.apiKey;
            enableKeywords.Checked = Properties.Settings.Default.enableKeywords;
            localUpload.Checked = Properties.Settings.Default.localStorage;
            autoStart.Checked = Properties.Settings.Default.autoStart;
            if(autoStart.Checked == true)
            {
                enableWatch.Checked = true;
                enableWatch_CheckedChanged(this, null);
            }
        }

        private void enableWatch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.watchFolder = watchFolder.Text;
            Properties.Settings.Default.octoPrintAddress = octoPrintAddress.Text;
            Properties.Settings.Default.apiKey = apiKey.Text;
            Properties.Settings.Default.enableKeywords = enableKeywords.Checked;
            Properties.Settings.Default.localStorage = localUpload.Checked;
            Properties.Settings.Default.autoStart = autoStart.Checked;
            Properties.Settings.Default.Save();
            if (enableWatch.Checked == true) {
                fsWatcher.Path = watchFolder.Text;
                fsWatcher.Filter = "*.gco*"; // only watch for gcode
                fsWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fsWatcher.Changed += new FileSystemEventHandler(OnChanged);
                fsWatcher.EnableRaisingEvents = true;
                statusLabel.Text = "Watching Folder for files.";
            } else
            {
                fsWatcher.EnableRaisingEvents = false;
                statusLabel.Text = "Watching disabled.";
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
                fsWatcher.EnableRaisingEvents = false;
                do_upload(e.FullPath);

        }

        private void do_upload(string filename)
        {
            System.Threading.Thread.Sleep(5000);
            NameValueCollection parameters = new NameValueCollection();
            string url = octoPrintAddress.Text + "/api/files/";
            string prepend = "http://";
            if(octoPrintAddress.Text.StartsWith("http://"))
            {
                prepend = "";
            }
            if(octoPrintAddress.Text.StartsWith("https://"))
            {
                prepend = "";
            }
            string uploadName = Path.GetFileName(filename); // need to get just the filename portion
            string uploadedFileStatus = "Uploaded " + uploadName;
            if (localUpload.Checked == true)
            {
                url = url + "local";
            }
            else
            {
                url = url + "sdcard";
            }
            // process filename here.
            if(enableKeywords.Checked == true)
            {
                if(uploadName.Contains("-select.gco"))
                {
                    parameters.Add("select", "true");
                    uploadName = uploadName.Replace("-select.gco", ".gco");
                    uploadedFileStatus += " as " + uploadName;
                } 
                if (uploadName.Contains("-print.gco"))
                {
                    parameters.Add("print", "true");
                    uploadName = uploadName.Replace("-print.gco", ".gco");
                    uploadedFileStatus += " as " + uploadName;
                }
            }
            else
            {
                parameters.Add("select", "false");
                parameters.Add("print", "false");
            }
            UploadMultipart(File.ReadAllBytes(filename), uploadName, "application/octet-stream", prepend + url, apiKey.Text, parameters);

            statusLabel.Text = uploadedFileStatus;

        }


        public void UploadMultipart(byte[] file, string filename, string contentType, string url, string apiKey, NameValueCollection parameters)
        {
            var webClient = new WebClient();
            string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
            webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);
            webClient.Headers.Add("X-Api-Key", apiKey);
            webClient.QueryString = parameters;
            var fileData = webClient.Encoding.GetString(file);
            var package = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"file\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n{3}\r\n--{0}--\r\n", boundary, filename, contentType, fileData);

            var nfile = webClient.Encoding.GetBytes(package);

            byte[] resp = webClient.UploadData(url, "POST", nfile);
            fsWatcher.EnableRaisingEvents = true;
        }

        private void pickWatchFolder_Click(object sender, EventArgs e)
        {
            folderPicker.ShowNewFolderButton = true; // they can make new folders, duh!
            folderPicker.RootFolder = System.Environment.SpecialFolder.MyComputer;

            DialogResult result = folderPicker.ShowDialog();
            if(result == DialogResult.OK)
            {
                watchFolder.Text = folderPicker.SelectedPath; 
            }
        } 

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.watchFolder = watchFolder.Text ;
            Properties.Settings.Default.octoPrintAddress = octoPrintAddress.Text;
            Properties.Settings.Default.apiKey = apiKey.Text;
            Properties.Settings.Default.enableKeywords = enableKeywords.Checked;
            Properties.Settings.Default.localStorage = localUpload.Checked;
            Properties.Settings.Default.autoStart = autoStart.Checked;
            Properties.Settings.Default.Save();
        }
    }


    
}

