using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using Microsoft.AspNetCore.Mvc;
using Amazon.S3.Model;

namespace ApiForMgok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BucketController : ControllerBase
    {
        private readonly IAmazonS3 _amazonS3;

        public BucketController(IAmazonS3 amazonS3)
        {
            _amazonS3 = amazonS3;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBucketAsync(string bucketName)
        {
            var bucketExist = await AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
            if (bucketExist) return BadRequest($"Bucket {bucketName} already exist");
            await _amazonS3.PutBucketAsync(bucketName);
            return Created("buckets", $"Bucket {bucketName} created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBucketsAsync()
        {
            var data = await _amazonS3.ListBucketsAsync();
            var buckets = data.Buckets.Select(b => b.BucketName);
            return Ok(buckets);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBucketsAsync(string name)
        {
            await _amazonS3.DeleteBucketAsync(name);
            return NoContent();
        }
    }
}