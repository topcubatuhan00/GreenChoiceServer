using GreenChoice.Domain.Dtos.Response;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Models.SustainabilityCriteriaModels;

namespace GreenChoice.Application.Services;

public class SustainabilityCriteriaService : ISustainabilityCriteriaService
{
    public Task Create(CreateSustainabilityCriteriaModel model)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<PaginationHelper<SustainabilityCriteria>>> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<SustainabilityCriteria>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UpdateSustainabilityCriteriaModel model)
    {
        throw new NotImplementedException();
    }
}
