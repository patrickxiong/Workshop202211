using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using WebClient;

namespace FeatureSwitch
{
    public class FeatureSwitch
    {
        static Dictionary<string,bool> features=new Dictionary<string,bool>();

        public static void LoadConfig()
        {
            FeatureClient _featureClient=new FeatureClient(null);

            FeatureItem[] featureItems = _featureClient.LoadConfigureFile();

            features = new Dictionary<string, bool>();
            foreach (var featureItem in featureItems)
            {
                var key = $"{featureItem.FeatureCode}:{featureItem.Version}";
                features.Add(key, featureItem.Enabled);
            }
        }

        public static bool Enabled(string FeatureCode, string Version)
        {
            var key = $"{FeatureCode}:{Version}";
            if (features.ContainsKey(key))
            {
                return features[key];
            }
            return false;
        }
    }
}
