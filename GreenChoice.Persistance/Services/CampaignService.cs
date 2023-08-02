using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.CampaignModels;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class CampaignService : ICampaignService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public CampaignService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task Create(CreateCampaignModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.campaignQueryRepository.GetByName(model.Name);
            if (check != null) throw new Exception("Already Defined Campaign");

            var entity = _mapper.Map<Campaign>(model);
            await context.Repositories.campaignCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<Campaign>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.campaignQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<Campaign>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var campaigns = result.Items.Select(item => _mapper.Map<Campaign>(item)).ToList();

            paginationHelper.Items = campaigns;

            return ResponseDto<PaginationHelper<Campaign>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Campaign>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.campaignQueryRepository.GetById(id);
            return ResponseDto<Campaign>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkCampaign = await context.Repositories.campaignQueryRepository.GetById(id);
            if (checkCampaign == null) throw new Exception("Not Found");

            await context.Repositories.campaignCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateCampaignModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var checkCampaign = await context.Repositories.campaignQueryRepository.GetById(model.Id);
            if (checkCampaign == null) throw new Exception("Not Found");

            var entity = _mapper.Map<Campaign>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.campaignCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
    #endregion
}
