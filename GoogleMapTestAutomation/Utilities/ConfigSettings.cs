using System;

namespace GoogleMapTestAutomation.Utilities
{
    //This class contains the properties which can be initialized using Configurations\configSettings.json file
    internal class ConfigSettings
    {
        public string BrowserType { get; set; }
        public string BaseUrl { get; set; }
    }
}
