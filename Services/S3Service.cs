using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ApiForMgok.Interfaces.Service;

namespace ApiForMgok.Services
{
    public class S3Service : IS3Service
    {
        private readonly ILogger<S3Service> _logger;
        private readonly IAmazonS3 _client;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public S3Service(IConfiguration configuration, ILogger<S3Service> logger, HttpClient httpClient)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClient = httpClient;

            var config = new AmazonS3Config
            {
                ServiceURL = configuration["YandexObjectStorage:Endpoint"],
                RegionEndpoint = Amazon.RegionEndpoint.EUIsoeWest1
            };

            _client = new AmazonS3Client(configuration["YandexObjectStorage:AccessKey"],
                configuration["YandexObjectStorage:SecretKey"],
                config);
        }
        
        public async Task<string> UploadPhotoFromUrlAsync(string photoUrl, string chatId)
        {
            try
            {
                _logger.LogInformation($"Downloading photo from URL: {photoUrl}");
                
                var photoStream = await DownloadPhotoAsync(photoUrl);

                
                var fileName = $"{Guid.NewGuid()}.jpg";
                
                var photoPath = $"{chatId}/{fileName}";
                
                var uploadedPhotoUrl = await UploadFileAsync(photoStream, photoPath);

                _logger.LogInformation($"File uploaded successfully. Photo URL: {uploadedPhotoUrl}");

                return uploadedPhotoUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error uploading photo: {ex.Message}");
                throw;
            }
        }
        
        private async Task<Stream> DownloadPhotoAsync(string photoUrl)
        {
            try
            {
                var response = await _httpClient.GetAsync(photoUrl);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStreamAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error downloading photo from URL {photoUrl}: {ex.Message}");
                throw;
            }
        }
        
        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                var bucketName = _configuration["YandexObjectStorage:BucketName"];
                var endpoint = _configuration["YandexObjectStorage:Endpoint"];
        
                if (string.IsNullOrEmpty(bucketName) || string.IsNullOrEmpty(endpoint))
                {
                    throw new InvalidOperationException("BucketName or Endpoint is not configured correctly.");
                }
        
                var fileKey = $"photos/{fileName}"; 

                var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = fileKey,
                    InputStream = fileStream,
                    ContentType = "application/octet-stream"
                };

                _logger.LogInformation($"Uploading file to S3: {fileKey}");

                var response = await _client.PutObjectAsync(request);

                // Формируем правильный URL
                return $"{endpoint}/{bucketName}/photos/{fileName}";
            }
            catch (AmazonS3Exception ex)
            {
                _logger.LogError($"Amazon S3 Exception during file upload: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"General Exception during file upload: {ex.Message}");
                throw;
            }
        }
        
        public async Task<Stream> GetFileAsync(string fileName)
        {
            var request = new GetObjectRequest
            {
                BucketName = _configuration["YandexObjectStorage:BucketName"],
                Key = fileName
            };

            var response = await _client.GetObjectAsync(request);
            return response.ResponseStream;
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _configuration["YandexObjectStorage:BucketName"],
                Key = fileName
            };

            await _client.DeleteObjectAsync(request);
        }
    }
}
