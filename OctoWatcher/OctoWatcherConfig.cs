using System;
using System.Collections;
using System.Xml;
using System.Text;
using System.Configuration;


namespace OctoWatcher.Config
{
    public class ServerInfoSection : ConfigurationSection
    {
     /*   [ConfigurationProperty("profileName", DefaultValue = "New Profile", IsRequired = true)]
        public String profileName
        {
            get
            {
                return (String)this["profileName"];
            }
            set
            {
                this["profileName"] = value;
            }

        }*/
        [ConfigurationProperty("watchFolder",DefaultValue = null,IsRequired = true)]
        public String watchFolder
        {
            get
            {
                return (String)this["watchFolder"];
            }
            set
            {
                this["watchFolder"] = value;
            }
        }

        [ConfigurationProperty("octoPrintAddress", DefaultValue = null, IsRequired = true)]
        public String octoPrintAddress
        {
            get
            {
                return (String)this["octoPrintAddress"];
            }
            set
            {
                this["octoPrintAddress"] = value;
            }
        }

        [ConfigurationProperty("apiKey", DefaultValue = null, IsRequired = true)]
        public String apiKey
        {
            get
            {
                return (String)this["apiKey"];
            }
            set
            {
                this["apiKey"] = value;
            }
        }

        [ConfigurationProperty("enableKeywords", DefaultValue = "true", IsRequired =false)]
        public Boolean enableKeywords
        {
            get
            {
                return (Boolean)this["enableKeywords"];
            }
            set
            {
                this["enableKeywords"] = value;
            }
            
        }
        
        [ConfigurationProperty("localUpload", DefaultValue = "true", IsRequired =false)]
        public Boolean localUpload
        {
            get
            {
                return (Boolean)this["localUpload"];
            }
            set
            {
                this["localUpload"] = value;
            }
        }

        [ConfigurationProperty("autoStart", DefaultValue = "false", IsRequired =false)] 
        public Boolean autoStart
        {
            get
            {
                return (Boolean)this["autoStart"];
            }
            set
            {
                this["autoStart"] = value;
            }
        }
    }

}
