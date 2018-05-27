using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ImageRecognitionSample.ImageRecognition
{
    internal class ByteArrayContentFactory
    {
        public static ByteArrayContent CreateFromImage(string imageFilePath)
        {
            var byteData = GetImageAsByteArray(imageFilePath);
            var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return content;

        }

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            using (var binaryReader = new BinaryReader(fileStream))
            {
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}