using ModelLib;
using System.Text.Json;

namespace WebClient
{
    public class FeatureClient
    {
        public static string ConfigFile = "Features.json";
        public static string ApiUrl = "";
        private IEncodeDecode _decoder;

        public FeatureClient(IEncodeDecode decoder)
        {
            _decoder = decoder;
        }
        //call api , save to config file
        public void GetFeatures()
        {
            //call api

        }

        FeatureItem[] CallApi()
        {
            return null;
        }

        private void SaveConfigureFile(FeatureItem[] Items)
        {
            var jsonString = JsonSerializer.Serialize(Items);
            var encoded = _decoder.Encode(jsonString);
            File.WriteAllText(ConfigFile, encoded);
        }



        public FeatureItem[] LoadConfigureFile()
        {
            var fileContent = File.ReadAllText(ConfigFile);
            var decoded = _decoder.Decode(fileContent);
            var featureItem = JsonSerializer.Deserialize<FeatureItem[]>(decoded);
            return featureItem;
        }
    }
}