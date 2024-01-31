using AutoMapper;
using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.FavoritesModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Persistance.Services;

public class FavoritesService : IFavoritesService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public FavoritesService
    (
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    #endregion

    public async Task CreateFavorites(int userId, int productId)
    {
        using (var context = _unitOfWork.Create())
        {
            await context.Repositories.favoriteCommandRepository.CreateFavorites(userId, productId);
            context.SaveChanges();
        }
    }

    public async Task<IList<ResponseFavoritesModel>> GetAllFavorites(int userId)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.favoriteQueryRepository.GetAllFavorites(userId);
            return result;
        }
    }

    public async Task<ResponseFavoritesModel> GetFavorites(int userId, int productId)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.favoriteQueryRepository.GetFavorites(userId, productId);
            return result;
        }
    }

    public async Task RemoveFavorites(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            await context.Repositories.favoriteCommandRepository.RemoveFavorites(id);
            context.SaveChanges();
        }
    }
}
