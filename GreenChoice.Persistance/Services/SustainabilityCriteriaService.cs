using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.SustainabilityCriteriaModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class SustainabilityCriteriaService : ISustainabilityCriteriaService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public SustainabilityCriteriaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    public async Task Create(CreateSustainabilityCriteriaModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<SustainabilityCriteria>(model);
            await context.Repositories.sustainabilityCriteriaCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<SustainabilityCriteria>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.sustainabilityCriteriaQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<SustainabilityCriteria>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var products = result.Items.Select(item => _mapper.Map<SustainabilityCriteria>(item)).ToList();

            paginationHelper.Items = products;

            return ResponseDto<PaginationHelper<SustainabilityCriteria>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<SustainabilityCriteria>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.sustainabilityCriteriaQueryRepository.GetById(id);
            return ResponseDto<SustainabilityCriteria>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkProduct = await context.Repositories.sustainabilityCriteriaQueryRepository.GetById(id);
            if (checkProduct == null) throw new Exception("Not Found");

            await context.Repositories.sustainabilityCriteriaCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateSustainabilityCriteriaModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkProduct = await context.Repositories.sustainabilityCriteriaQueryRepository.GetById(model.Id);
            if (checkProduct == null) throw new Exception("Not Found");

            var entity = _mapper.Map<SustainabilityCriteria>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.sustainabilityCriteriaCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
}
