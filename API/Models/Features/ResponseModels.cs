using System;

namespace Workshop2022.API.Models.Features
{
    public class FeaturesResponse
    {
        // populate as needed
        public FeatureItem[] features { get; set; }
    }

    public class FeatureItem
    {
        public string FeatureCode { get; set; }
        public string Version { get; set; }
        public string Enabled { get; set; }

    }

}
