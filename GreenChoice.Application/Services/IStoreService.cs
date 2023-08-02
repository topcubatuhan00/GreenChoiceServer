using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.StoreModels;

namespace GreenChoice.Application.Services;

public interface IStoreService
{
    Task<ResponseDto<Store>> GetById(int id);
    Task<ResponseDto<PaginationHelper<Store>>> GetAll(PaginationRequest request);
    Task Create(CreateStoreModel model);
    Task Update(UpdateStoreModel model);
    Task Remove(int id);
}
