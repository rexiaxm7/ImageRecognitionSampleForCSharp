using System.Net.Http;
using System.Threading.Tasks;
using ImageRecognitionSample.ImageRecognition.Result;
using Newtonsoft.Json;

namespace ImageRecognitionSample.ImageRecognition
{
    public class ImageRecognitionService
    {
        private readonly string _predictionKey;
        private readonly string _predictionUrl;

        public ImageRecognitionService(string predictionKey, string predictionUrl)
        {
            _predictionKey = predictionKey;
            _predictionUrl = predictionUrl;
        }

        public async Task<PredictionResult> GetPredictionResult(string imageFilePath)
        {
            using (var content = ByteArrayContentFactory.CreateFromImage(imageFilePath))
            {
                var client = CreateHttpClientWithPredictionKey(_predictionKey);
                var response = await client.PostAsync(_predictionUrl, content);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PredictionResult>(result);
            }
        }

        private static HttpClient CreateHttpClientWithPredictionKey(string predictionKey)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);
            return client;
        }
    }
}