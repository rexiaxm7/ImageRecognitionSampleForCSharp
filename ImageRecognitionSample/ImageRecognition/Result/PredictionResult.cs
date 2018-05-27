namespace ImageRecognitionSample.ImageRecognition.Result
{
    public class PredictionResult
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string Iteration { get; set; }
        public string Created { get; set; }
        public Prediction[] Predictions { get; set; }
    }
}