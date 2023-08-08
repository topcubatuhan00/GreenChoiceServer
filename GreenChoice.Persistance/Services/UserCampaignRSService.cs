using AutoMapper;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.UserCampaignRSModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Application.Services;

public class UserCampaignRSService : IUserCampaignRSService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public UserCampaignRSService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    public async Task Create(CreateUserCampaignRSModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<UserCampaignRS>(model);
            await context.Repositories.userCampaignRSCommandRepository.AddAsync(entity);

            context.SaveChanges();
        }
    }

    public async Task<ResponseDto<PaginationHelper<UserCampaignRS>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.userCampaignRSQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<UserCampaignRS>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var UserCampaignRSs = result.Items.Select(item => _mapper.Map<UserCampaignRS>(item)).ToList();

            paginationHelper.Items = UserCampaignRSs;

            return ResponseDto<PaginationHelper<UserCampaignRS>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<UserCampaignRS>> GetById(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.userCampaignRSQueryRepository.GetById(id);
            return ResponseDto<UserCampaignRS>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.userCampaignRSQueryRepository.GetById(id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.userCampaignRSCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(UpdateUserCampaignRSModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.userCampaignRSQueryRepository.GetById(model.Id);
            if (check == null) throw new Exception("Not Found");

            var entity = _mapper.Map<UserCampaignRS>(model);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdaterName = "Admin";
            await context.Repositories.userCampaignRSCommandRepository.UpdateAsync(entity);
            context.SaveChanges();
        }
    }
}
