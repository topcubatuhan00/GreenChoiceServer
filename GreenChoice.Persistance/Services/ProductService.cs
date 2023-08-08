using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.ProductModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class ProductService : IProductService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task Create(CreateProductModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.productQueryRepository.GetByName(model.Name);
            if (check != null) throw new Exception("Already Defined Category");

            var entity = _mapper.Map<Product>(model);
            await context.Repositories.productCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<Product>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.productQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<Product>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var products = result.Items.Select(item => _mapper.Map<Product>(item)).ToList();

            paginationHelper.Items = products;

            return ResponseDto<PaginationHelper<Product>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Product>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.productQueryRepository.GetById(id);
            return ResponseDto<Product>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkProduct = await context.Repositories.productQueryRepository.GetById(id);
            if (checkProduct == null) throw new Exception("Not Found");

            await context.Repositories.productCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateProductModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkProduct = await context.Repositories.productQueryRepository.GetById(model.Id);
            if (checkProduct == null) throw new Exception("Not Found");

            var entity = _mapper.Map<Product>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.productCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
    #endregion
}
