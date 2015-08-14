using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Temp.IO;
using Gajatko.IniFiles;

namespace OctoWatcher
{


    public partial class mainForm : Form
    {
        MyFileSystemWatcher fsWatcher = new MyFileSystemWatcher();
        string cfile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/octowatcher.ini";
        IniFile config = new IniFile();


        public mainForm()
        {
            InitializeComponent();

            if (File.Exists(cfile))
            {
                // it exists, let's load it.
                config = IniFile.FromFile(cfile);
            }
            else
            {
                config["Default"]["watchFolder"] = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                config["Default"]["octoPrintAddress"] = "http://octopi.local";
                config["Default"]["apiKey"] = "Enter API Key";
                config["Default"]["enableKeywords"] = "true";
                config["Default"]["localUpload"] = "true";
                config["Default"]["autoStart"] = "false";
                config.Save(cfile);
            }
            refreshProfileList();
           
            loadSettings();
        }

        private void refreshProfileList()
        {
            profileList.Items.Clear();
            string[] sections = config.GetSectionNames();
            foreach (string name in sections)
            {
                profileList.Items.Add(name);
            }
        }

        private void enableWatch_CheckedChanged(object sender, EventArgs e)
        {
            saveSettings();
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
            nfile = null;
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

        public void saveSettings()
        {
            string profileName = profileList.Text;
            config[profileName]["watchFolder"] = watchFolder.Text;
            config[profileName]["octoPrintAddress"] = octoPrintAddress.Text;
            config[profileName]["apiKey"] = apiKey.Text;
            config[profileName]["enableKeywords"] = enableKeywords.Checked.ToString();
            config[profileName]["localUpload"] = localUpload.Checked.ToString();
            config[profileName]["autoStart"] = autoStart.Checked.ToString();
            config.Save(cfile);
            config = IniFile.FromFile(cfile);
        }

        public void loadSettings()
        {
            string profileName = profileList.Text;
            if(config[profileName]!= null)
            {
                // it exists, load the profile
                watchFolder.Text = config[profileName]["watchFolder"];
                octoPrintAddress.Text = config[profileName]["octoPrintAddress"];
                apiKey.Text = config[profileName]["apiKey"];
                enableKeywords.Checked = Convert.ToBoolean(config[profileName]["enableKeywords"]);
                localUpload.Checked = Convert.ToBoolean(config[profileName]["localUpload"]);
                autoStart.Checked = Convert.ToBoolean(config[profileName]["autoStart"]);
            } else
            {
                // set to defaults
                profileName = "Default";
                watchFolder.Text = config[profileName]["watchFolder"];
                octoPrintAddress.Text = config[profileName]["octoPrintAddress"];
                apiKey.Text = config[profileName]["apiKey"];
                enableKeywords.Checked = Convert.ToBoolean(config[profileName]["enableKeywords"]);
                localUpload.Checked = Convert.ToBoolean(config[profileName]["localUpload"]);
                autoStart.Checked = Convert.ToBoolean(config[profileName]["autoStart"]);
            }
                 
        }
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettings();
        }

        private void saveProfile_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void deleteProfile_Click(object sender, EventArgs e)
        {

        }

        private void removeProfile(string selectedText)
        {

        }

        private void profileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSettings();
        }
    }


    
}

