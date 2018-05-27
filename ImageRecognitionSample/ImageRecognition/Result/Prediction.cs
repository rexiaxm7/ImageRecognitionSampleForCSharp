namespace ImageRecognitionSample.ImageRecognition.Result
{
    public class Prediction
    {
        public float Probability { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }
        public Region Region { get; set; }
    }
}