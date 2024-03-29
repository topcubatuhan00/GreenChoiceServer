﻿using AutoMapper;
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

    public async Task<ResponseDto<PaginationHelper<GetAllProductModel>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.productQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<GetAllProductModel>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var products = result.Items.Select(item => _mapper.Map<GetAllProductModel>(item)).ToList();

            paginationHelper.Items = products;

            return ResponseDto<PaginationHelper<GetAllProductModel>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<GetByIdProductResponse>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.productQueryRepository.GetById(id);
            return ResponseDto<GetByIdProductResponse>.Success(result, 200);
        }
    }

    public async Task<ResponseDto<IList<HomeResponseProductModel>>> GetForHome(int productCount)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.productQueryRepository.GetForHome(productCount);
            return ResponseDto<IList<HomeResponseProductModel>>.Success(result, 200);
        }
    }

    public async Task<ResponseDto<IList<GetByStoreIdProductModel>>> GetWithStoreId(int storeId)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.productQueryRepository.GetWithStoreId(storeId);
            return ResponseDto<IList<GetByStoreIdProductModel>>.Success(result, 200);
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

    public async Task UpdateScore(UpdateSustainabilityScoreModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var product = await context.Repositories.productQueryRepository.GetById(model.Id);
            var productScore = product.SustainabilityScore;
            var oldScore = Convert.ToSingle(productScore);
            var newScore = (oldScore + Convert.ToSingle(model.Number))/2;

            await context.Repositories.productCommandRepository.UpdateScoreAsync(newScore.ToString(), model.Id);
        }
    }
    #endregion
}
