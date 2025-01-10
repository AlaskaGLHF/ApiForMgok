using System.IO;
using System.Threading.Tasks;

namespace ApiForMgok.Interfaces.Service
{
    public interface IS3Service
    {
        
        Task<string> UploadPhotoFromUrlAsync(string photoUrl, string chatId);
        
        Task<string> UploadFileAsync(Stream fileStream, string fileName);
        
        Task<Stream> GetFileAsync(string fileName);
        
        Task DeleteFileAsync(string fileName);
    }
}