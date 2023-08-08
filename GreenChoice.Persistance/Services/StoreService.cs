using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.StoreModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class StoreService : IStoreService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    public async Task Create(CreateStoreModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<Store>(model);
            await context.Repositories.storeCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<Store>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.storeQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<Store>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var Stores = result.Items.Select(item => _mapper.Map<Store>(item)).ToList();

            paginationHelper.Items = Stores;

            return ResponseDto<PaginationHelper<Store>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Store>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.storeQueryRepository.GetById(id);
            return ResponseDto<Store>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkStore = await context.Repositories.storeQueryRepository.GetById(id);
            if (checkStore == null) throw new Exception("Not Found");

            await context.Repositories.storeCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateStoreModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkStore = await context.Repositories.storeQueryRepository.GetById(model.Id);
            if (checkStore == null) throw new Exception("Not Found");

            var entity = _mapper.Map<Store>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.storeCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
}
