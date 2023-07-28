using GreenChoice.Application.Services.Utilities;

namespace GreenChoice.Persistance.Services.Utilities;

public partial class FileService : IFileService
{
    public string GetFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);

        switch (ext.ToLower())
        {
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            default:
                return "application/octet-stream";
        }
    }
}
