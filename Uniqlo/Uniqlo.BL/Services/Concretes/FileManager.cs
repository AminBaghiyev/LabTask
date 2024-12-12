using Microsoft.AspNetCore.Http;
using Uniqlo.BL.Utilities;

namespace Uniqlo.BL.Services.Concretes;

public static class FileManager
{
    public static async Task<string> SaveAsync(this IFormFile file, string wwwroot, string folder)
    {
        string uploadPath = Path.Combine(wwwroot, "uploads", folder);

        if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
        
        string filename = Guid.NewGuid().ToString() + file.FileName;

        using (FileStream item = new(Path.Combine(uploadPath, filename), FileMode.Create))
        {
            await file.CopyToAsync(item);
        }

        return filename;
    }

    public static bool CheckSize(this IFormFile file, int size, FileSizeTypes sizeType) => file.Length < size * ((int) sizeType);

    public static bool CheckType(this IFormFile file, string type) => file.ContentType.Contains(type);
}
