using ApiForMgok.Dtos;
using ApiForMgok.Services;

namespace ApiForMgok.Interfaces.Service;

public interface IS3Service
{
    
    public Task<S3ObjectDto> S3Service (IConfiguration configuration, ILogger<S3Service> logger);
    
}