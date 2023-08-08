using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductCriteriaRSModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class ProductCriteriaRSService : IProductCriteriaRSService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public ProductCriteriaRSService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    public async Task Create(CreateProductCriteriaRSModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<ProductCriteriaRS>(model);
            await context.Repositories.productCriteriaRSCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<ProductCriteriaRS>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.productCriteriaRSQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<ProductCriteriaRS>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var products = result.Items.Select(item => _mapper.Map<ProductCriteriaRS>(item)).ToList();

            paginationHelper.Items = products;

            return ResponseDto<PaginationHelper<ProductCriteriaRS>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<ProductCriteriaRS>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.productCriteriaRSQueryRepository.GetById(id);
            return ResponseDto<ProductCriteriaRS>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkProduct = await context.Repositories.productCriteriaRSQueryRepository.GetById(id);
            if (checkProduct == null) throw new Exception("Not Found");

            await context.Repositories.productCriteriaRSCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateProductCriteriaRSModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkProduct = await context.Repositories.productCriteriaRSQueryRepository.GetById(model.Id);
            if (checkProduct == null) throw new Exception("Not Found");

            var entity = _mapper.Map<ProductCriteriaRS>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.productCriteriaRSCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
}
