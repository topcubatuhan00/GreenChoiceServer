using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.SustainabilityCriteriaModels;

namespace GreenChoice.Application.Services;

public interface ISustainabilityCriteriaService
{
    Task<ResponseDto<SustainabilityCriteria>> GetById(int id);
    Task<ResponseDto<PaginationHelper<SustainabilityCriteria>>> GetAll(PaginationRequest request);
    Task Create(CreateSustainabilityCriteriaModel model);
    Task Update(UpdateSustainabilityCriteriaModel model);
    Task Remove(int id);
}
