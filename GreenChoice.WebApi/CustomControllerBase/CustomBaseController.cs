using GreenChoice.Domain.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.CustomControllerBase;

public class CustomBaseController : ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(ResponseDto<T> responseDto)
    {
        return new ObjectResult(responseDto)
        {
            StatusCode = Response.StatusCode
        };
    }
}
