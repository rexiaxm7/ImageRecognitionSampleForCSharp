using System;
using ImageRecognitionSample.ImageRecognition;

namespace ImageRecognitionSample
{
    internal class Program
    {
        // Replace your prediction key.
        private const string PredictionKey = "";
        // Replace your prediction api url.
        private const string PredictionApiUrl = "";

        private static void Main()
        {
            Console.Write("Enter image file path: ");

            var imageFilePath = Console.ReadLine();
            var service = new ImageRecognitionService(PredictionKey, PredictionApiUrl);
            var predictionResult = service.GetPredictionResult(imageFilePath).Result;

            Console.WriteLine("\nThis Image is ...");
            foreach (var prediction in predictionResult.Predictions)
            {
                Console.WriteLine($"{prediction.TagName} : {prediction.Probability:F5}");
            }

            Console.WriteLine("\nHit ENTER to exit...");
            Console.ReadLine();
        }
    }
}
