using ModelLib;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Workshop2022.API.Models.Features;

namespace WebClient
{
    public class FeatureClient
    {
        public static string ConfigFile = "Features.json";
        public static string ApiUrl = "http://localhost:5001/";
        private IEncodeDecode _decoder;

        public FeatureClient(IEncodeDecode decoder)
        {
            _decoder = decoder;
        }

        //call api , save to config file
        public async void GetFeatures()
        {
            //call api
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("API/features", new FeaturesRequest
                {
                    App = "TestApp01",
                    Ip = "50.6.10.0",
                    Device = "Windows",
                    CustomFields = new string[5],
                    UserId = "NK109617"
                });

                var featureItems = response.Content.ReadFromJsonAsync<FeatureItem[]>().Result;
                if (featureItems != null)
                {
                    SaveConfigureFile(featureItems);
                }
            }
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