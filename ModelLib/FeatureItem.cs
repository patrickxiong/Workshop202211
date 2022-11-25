using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class FeatureItem
    {
        public FeatureItem(string featureCode, string version, bool enabled)
        {
            FeatureCode = featureCode;
            Version = version;
            Enabled = enabled;
        }

        public string FeatureCode { get; }
        public string Version { get; }
        public bool Enabled { get; }
    }
}
