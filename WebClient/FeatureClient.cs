using ModelLib;

namespace WebClient
{
    public class FeatureClient
    {
        public static string ConfigFile = "Features.json";
        public static string ApiUrl = "";
        public FeatureClient(IEncodeDecode decoder)
        {

        }
        //call api , save to config file
        public void GetFeatures()
        {
            //call api

        }

        FeatureItem[] CallApi()
        {

        }

        private void SaveConfigureFile(FeatureItem[] Items)
        {

        }

        public static FeatureItem[] LoadConfigureFile()
        {
            return null;
        }
    }
}