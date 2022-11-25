namespace Workshop2022.API.Models.Services
{

    //DO NOT CHANGE
    public class FeatureConfigEntity
    {
        public string App { get; set; }
        public string UserGroup { get; set; }
        public string IpMask { get; set; }
        public string Device { get; set; }

        public string[] CustomFields { get; set; } = new string[5];

        public string FeatureCode { get; set; }

        public string Version { get; set; }

        public bool Enabled { get; set; }

        
        
        // skeleton functions only
        public bool IsIpSelected(string ip)
        {
            // fake logic
            return ip == IpMask || IpMask == string.Empty;
        }
        public bool IsUserSelected(string userid)
        {
            // fake logic
            return userid == UserGroup || UserGroup == string.Empty;
        }

        public bool IsDeviceSelected(string device)
        {
            //fake logic
            return device == Device || Device == string.Empty;
        }
    }
}
