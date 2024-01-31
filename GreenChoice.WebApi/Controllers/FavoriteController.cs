using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.FavoritesModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FavoriteController : CustomBaseController
{
    #region Fields
    private readonly IFavoritesService _favoriteService;
    #endregion

    #region Ctor
    public FavoriteController
    (
        IFavoritesService favoritesService
    )
    {
        _favoriteService = favoritesService;
    }
    #endregion

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(int userId)
    {
        var result = await _favoriteService.GetAllFavorites(userId);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(FavoriteGetModel model)
    {
        var result = await _favoriteService.GetFavorites(model.UserId, model.ProductId);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateFavoriteModel model)
    {
        await _favoriteService.CreateFavorites(model.UserId, model.ProductId);
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Delete(int id)
    {
        await _favoriteService.RemoveFavorites(id);
        return Ok();
    }
}
