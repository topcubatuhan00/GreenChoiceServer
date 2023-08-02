using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.StoreModels;

namespace GreenChoice.Application.Services;

public class StoreService : IStoreService
{
    public Task Create(CreateStoreModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<Store>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<Store>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateStoreModel model)
    {
        throw new NotImplementedException();
    }
}
