using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : CustomBaseController
{
    #region Fields
    private readonly IProductService _productService;
    #endregion

    #region Ctor
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    #endregion

    #region List
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
    {
        var categories = await _productService.GetAll(request);

        return CreateActionResultInstance(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _productService.GetById(id);

        return CreateActionResultInstance(category);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductModel model)
    {
        await _productService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProductModel model)
    {
        await _productService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _productService.Remove(id);
        return Ok();
    }
    #endregion
}
