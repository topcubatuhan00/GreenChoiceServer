using AutoMapper;
using GreenChoice.Application.Services;
using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.SettingModels;
using GreenChoice.Domain.UnitOfWork;

namespace GreenChoice.Persistance.Services;

public class SettingsService : ISettingsService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public SettingsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task Create(SettingCreateModel model)
    {
        using var context = _unitOfWork.Create();
        var check = await context.Repositories.settingsQueryRepository.GetByName(model.Name);
        if (check != null) throw new Exception("Already Defined Settings");

        var settings = _mapper.Map<Settings>(model);

        await context.Repositories.settingsCommandRepository.AddAsync(settings);

        context.SaveChanges();
    }

    public async Task<ResponseDto<PaginationHelper<Settings>>> GetAll(PaginationRequest request)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.settingsQueryRepository.GetAll(request);

            var paginationHelper = new PaginationHelper<Settings>(result.TotalCount, request.PageSize, request.PageNumber, null);

            var settings = result.Items.Select(item => _mapper.Map<Settings>(item)).ToList();

            paginationHelper.Items = settings;

            return ResponseDto<PaginationHelper<Settings>>.Success(paginationHelper, 200);
        }
    }

    public async Task<ResponseDto<Settings>> GetById(int Id)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.settingsQueryRepository.GetById(Id);
            return ResponseDto<Settings>.Success(result, 200);
        }
    }

    public async Task<ResponseDto<Settings>> GetByName(string Name)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.settingsQueryRepository.GetByName(Name);
            return ResponseDto<Settings>.Success(result, 200);
        }
    }

    public async Task Remove(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.settingsQueryRepository.GetById(id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.settingsCommandRepository.RemoveByIdAsync(id);
            context.SaveChanges();
        }
    }

    public async Task Update(Settings model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.settingsQueryRepository.GetById(model.Id);
            if (check == null) throw new Exception("Not Found");

            await context.Repositories.settingsCommandRepository.UpdateAsync(model);
            context.SaveChanges();
        }
    }
    #endregion
}
