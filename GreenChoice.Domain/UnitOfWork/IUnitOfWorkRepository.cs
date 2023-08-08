using GreenChoice.Domain.Repositories.CampaignRepositories;
using GreenChoice.Domain.Repositories.CategoryRepositories;
using GreenChoice.Domain.Repositories.CommentRepositories;
using GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;
using GreenChoice.Domain.Repositories.ProductRepositories;
using GreenChoice.Domain.Repositories.StoreRepositories;
using GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;
using GreenChoice.Domain.Repositories.UserCampaignRSRepositories;
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

    #region CategoryRepositories
    ICategoryCommandRepository categoryCommandRepository { get; }
    ICategoryQueryRepository categoryQueryRepository { get; }
    #endregion

    #region CommentRepositories
    ICommentCommandRepository commentCommandRepository { get; }
    ICommentQueryRepository commentQueryRepository { get;}
    #endregion

    #region ProductCriteriaRSRepositories
    IProductCriteriaRSCommandRepository productCriteriaRSCommandRepository { get; }
    IProductCriteriaRSQueryRepository productCriteriaRSQueryRepository { get; }
    #endregion

    #region ProductRepositories
    IProductCommandRepository productCommandRepository { get; }
    IProductQueryRepository productQueryRepository { get; }
    #endregion

    #region StoreRepositories
    IStoreCommandRepository storeCommandRepository { get; }
    IStoreQueryRepository storeQueryRepository { get; }
    #endregion

    #region SustainabilityCriteriaRepositories
    ISustainabilityCriteriaCommandRepository sustainabilityCriteriaCommandRepository { get;}
    ISustainabilityCriteriaQueryRepository sustainabilityCriteriaQueryRepository { get;}
    #endregion

    #region UserCampaignRSRepositories
    IUserCampaignRSCommandRepository userCampaignRSCommandRepository { get; }
    IUserCampaignRSQueryRepository userCampaignRSQueryRepository { get; }
    #endregion
}
