using GreenChoice.Domain.Repositories.CampaignRepositories;
using GreenChoice.Domain.Repositories.UserRepositories;

namespace GreenChoice.Domain.UnitOfWork;

public interface IUnitOfWorkRepository
{
    #region UserRepositories
    IUserCommandRepository userCommandRepository { get; }
    IUserQueryRepository userQueryRepository { get; }
    #endregion

    #region CampaignRepositories
    ICampaignCommandRepository campaignCommandRepository { get; }
    ICampaignQueryRepository campaignQueryRepository { get; }
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion

    #region
    #endregion
}
