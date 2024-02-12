using GreenChoice.Application.Services.Utilities;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : CustomBaseController
{
    #region Fields
    private readonly IFileService _fileService;
    #endregion

    #region Ctor
    public ImageController(IFileService fileService)
    {
        _fileService = fileService;
    }
    #endregion

    #region Methods
    [HttpGet("[action]/{fileName}")]
    public IActionResult GetImage(string fileName)
    {
        string path = "./Content/Images/" + fileName;

        if (!System.IO.File.Exists(path))
        {
            string defaultImagePath = "./Content/Images/defaultphoto.jpg";
            byte[] defaultImageBytes = System.IO.File.ReadAllBytes(defaultImagePath);
            string defaultImageMimeType = _fileService.GetFileType("defaultphoto.jpg");
            return File(defaultImageBytes, defaultImageMimeType);
        }

        byte[] fileBytes = System.IO.File.ReadAllBytes(path);
        string mimeType = _fileService.GetFileType(fileName);
        return File(fileBytes, mimeType);
    }
    #endregion
}
