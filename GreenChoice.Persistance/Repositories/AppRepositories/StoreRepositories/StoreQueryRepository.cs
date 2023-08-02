using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.StoreRepositories;

namespace GreenChoice.Persistance.Repositories.AppRepositories.StoreRepositories;

public class StoreQueryRepository : IStoreQueryRepository
{
    public PaginationHelper<Store> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Store> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
