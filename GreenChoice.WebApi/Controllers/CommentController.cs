using GreenChoice.Application.Services;
using GreenChoice.Domain.Core;
using GreenChoice.Domain.Models.CommentModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : CustomBaseController
{
    #region Fields
    private readonly ICommentService _commentService;
    private readonly ISettingsService _settingsService;
    #endregion

    #region Ctor
    public CommentController
    (
        ICommentService commentService, 
        ISettingsService settingsService
    )
    {
        _commentService = commentService;
        _settingsService = settingsService;
    }
    #endregion

    #region List
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(CommentListModel model)
    {
        var comment = await _commentService.GetAll(model.UserId, model.ProductId);

        return Ok(comment);
    }

    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> UpdateLike(int id)
    {
        try
        {
            await _commentService.UpdateLike(id);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var comment = await _commentService.GetById(id);

        return CreateActionResultInstance(comment);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllForHomePage()
    {
        var settingsCommentSize = await _settingsService.GetByName(SettingsDefaults.BestCommentHome);
        var products = await _commentService.GetForHome(Convert.ToInt32(settingsCommentSize.Data.Value));

        return CreateActionResultInstance(products);
    }
    #endregion

    #region Create
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCommentModel model)
    {
        await _commentService.Create(model);
        return Ok(model);
    }
    #endregion

    #region Update
    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateCommentModel model)
    {
        await _commentService.Update(model);
        return Ok();
    }
    #endregion

    #region Delete
    [HttpDelete("(id)")]
    public async Task<IActionResult> Remove(int id)
    {
        await _commentService.Remove(id);
        return Ok();
    }
    #endregion
}
