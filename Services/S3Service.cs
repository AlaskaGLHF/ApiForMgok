using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using ApiForMgok.Controllers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ApiForMgok.Services
{
    public class S3Service
    {
        private readonly ILogger<S3Service> _logger;
        private readonly IAmazonS3 _client;
        private readonly IConfiguration _configuration;

        public S3Service(IConfiguration configuration, ILogger<S3Service> logger)
        {
            _configuration = configuration;
            _logger = logger;

            // Настройка клиента S3 для Yandex Object Storage
            var config = new AmazonS3Config
            {
                ServiceURL = configuration["YandexObjectStorage:Endpoint"], // Например, https://storage.yandexcloud.net
                ForcePathStyle = true // Включение стиля пути, требуемого для Yandex
            };

            _client = new AmazonS3Client(
                configuration["YandexObjectStorage:AccessKey"],
                configuration["YandexObjectStorage:SecretKey"],
                config
            );
        }

        public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
        {
            try
            {
                _logger.LogInformation($"Starting upload of file {fileName}");

                var request = new PutObjectRequest
                {
                    BucketName = _configuration["YandexObjectStorage:BucketName"],
                    Key = fileName,
                    InputStream = fileStream,
                    ContentType = "application/octet-stream"
                };

                _logger.LogInformation("Sending PUT request to S3");

                var response = await _client.PutObjectAsync(request);

                _logger.LogInformation($"Upload completed successfully. Response status code: {response.HttpStatusCode}");

                return $"https://{_configuration["YandexObjectStorage:BucketName"]}.{_configuration["YandexObjectStorage:Endpoint"]}/{fileName}";
            }
            catch (AmazonS3Exception ex)
            {
                _logger.LogError(ex, $"Amazon S3 Exception during file upload: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"General Exception during file upload: {ex.Message}");
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
