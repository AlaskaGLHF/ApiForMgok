using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiForMgok.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class S3Controller : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;

        public S3Controller(IAmazonS3 s3Client)
        {
            _s3Client = s3Client ?? throw new ArgumentNullException(nameof(s3Client));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromBody] InputEvent input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.Url) ||
                    string.IsNullOrEmpty(input.BucketName) ||
                    string.IsNullOrEmpty(input.FileName))
                {
                    return BadRequest("All input parameters must be provided");
                }

                var fileContent = await DownloadFileAsync(input.Url);
                await UploadFileToS3Async(input.BucketName, input.FileName, fileContent);

                return Ok("File uploaded successfully");
            }
            catch (HttpRequestException httpEx)
            {
                return StatusCode(500, $"HTTP error: {httpEx.Message}");
            }
            catch (AmazonS3Exception s3Ex)
            {
                return StatusCode(500, $"S3 error: {s3Ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        private async Task<Stream> DownloadFileAsync(string url)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to download file. HTTP Status: {response.StatusCode}");
            }

            return await response.Content.ReadAsStreamAsync();
        }

        private async Task UploadFileToS3Async(string bucketName, string fileName, Stream fileContent)
        {
            var request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = fileName,
                InputStream = fileContent
            };

            await _s3Client.PutObjectAsync(request);
        }
    }

    public class InputEvent
    {
        public string Url { get; set; }       // URL файла
        public string BucketName { get; set; } // Имя S3-бакета
        public string FileName { get; set; }   // Имя файла в S3
    }
}