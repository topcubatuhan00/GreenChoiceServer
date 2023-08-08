using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.CategoryModels;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class CategoryService : ICategoryService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task Create(CreateCategoryModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.categoryQueryRepository.GetByName(model.Name);
            if (check != null) throw new Exception("Already Defined Category");

            var entity = _mapper.Map<Category>(model);
            await context.Repositories.categoryCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<Category>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.categoryQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<Category>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var categories = result.Items.Select(item => _mapper.Map<Category>(item)).ToList();

            paginationHelper.Items = categories;

            return ResponseDto<PaginationHelper<Category>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Category>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.categoryQueryRepository.GetById(id);
            return ResponseDto<Category>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkCategory = await context.Repositories.categoryQueryRepository.GetById(id);
            if (checkCategory == null) throw new Exception("Not Found");

            await context.Repositories.categoryCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateCategoryModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkCategory = await context.Repositories.categoryQueryRepository.GetById(model.Id);
            if (checkCategory == null) throw new Exception("Not Found");

            var entity = _mapper.Map<Category>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.categoryCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
    #endregion
}
