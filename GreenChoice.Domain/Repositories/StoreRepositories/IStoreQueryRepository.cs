using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.StoreRepositories;

public interface IStoreQueryRepository
{
    PaginationHelper<Store> GetAll(PaginationRequest request);
    Task<Store> GetById(int Id);
}
