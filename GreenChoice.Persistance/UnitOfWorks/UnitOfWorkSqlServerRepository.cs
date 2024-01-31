#region Usings
using GreenChoice.Domain.Repositories.CampaignRepositories;
using GreenChoice.Domain.Repositories.CategoryRepositories;
using GreenChoice.Domain.Repositories.CommentRepositories;
using GreenChoice.Domain.Repositories.FavoritesRepositories;
using GreenChoice.Domain.Repositories.ProductCriteriaRSRepositories;
using GreenChoice.Domain.Repositories.ProductRepositories;
using GreenChoice.Domain.Repositories.SettingsRepositories;
using GreenChoice.Domain.Repositories.StoreRepositories;
using GreenChoice.Domain.Repositories.SustainabilityCriteriaRepositories;
using GreenChoice.Domain.Repositories.UserCampaignRSRepositories;
using GreenChoice.Domain.Repositories.UserRepositories;
using GreenChoice.Domain.UnitOfWork;
using GreenChoice.Persistance.Repositories.AppRepositories.CampaignRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.CategoryRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.CommentRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.FavoritesRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.ProductCriteriaRSRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.ProductRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.SettingsRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.StoreRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.SustainabilityCriteriaRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.UserCampaignRSRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.UserRepositories;
using Microsoft.Data.SqlClient;
#endregion

namespace GreenChoice.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
{
    #region Fields

    #region User
    public IUserCommandRepository userCommandRepository { get; }
    public IUserQueryRepository userQueryRepository { get; }
    #endregion

    #region Campaign
    public ICampaignCommandRepository campaignCommandRepository { get; }
    public ICampaignQueryRepository campaignQueryRepository { get; }
    #endregion

    #region Category
    public ICategoryCommandRepository categoryCommandRepository { get; }
    public ICategoryQueryRepository categoryQueryRepository { get; }
    #endregion

    #region Comment
    public ICommentCommandRepository commentCommandRepository { get; }
    public ICommentQueryRepository commentQueryRepository { get; }
    #endregion

    #region ProductCriteriaRS
    public IProductCriteriaRSCommandRepository productCriteriaRSCommandRepository { get; }
    public IProductCriteriaRSQueryRepository productCriteriaRSQueryRepository { get; }
    #endregion

    #region Product
    public IProductCommandRepository productCommandRepository { get; }
    public IProductQueryRepository productQueryRepository { get; }
    #endregion

    #region Store
    public IStoreCommandRepository storeCommandRepository { get; }
    public IStoreQueryRepository storeQueryRepository { get; }
    #endregion

    #region SustainabilityCriteria
    public ISustainabilityCriteriaCommandRepository sustainabilityCriteriaCommandRepository { get; }
    public ISustainabilityCriteriaQueryRepository sustainabilityCriteriaQueryRepository { get; }
    #endregion

    #region UserCampaignRS
    public IUserCampaignRSCommandRepository userCampaignRSCommandRepository { get; }
    public IUserCampaignRSQueryRepository userCampaignRSQueryRepository { get; }
    #endregion

    #region Settings
    public ISettingsCommandRepository settingsCommandRepository { get; }

    public ISettingsQueryRepository settingsQueryRepository { get; }
    #endregion

    #region Favorites
    public IFavoriteCommandRepository favoriteCommandRepository { get; }

    public IFavoriteQueryRepository favoriteQueryRepository { get; }
    #endregion

    #endregion

    #region Ctor
    public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
    {
        #region User
        userCommandRepository = new UserCommandRepository(context, transaction);
        userQueryRepository = new UserQueryRepository(context, transaction);
        #endregion

        #region Campaign
        campaignCommandRepository = new CampaignCommandRepository(context, transaction);
        campaignQueryRepository = new CampaignQueryRepository(context, transaction);
        #endregion

        #region Category
        categoryCommandRepository = new CategoryCommandRepository(context, transaction);
        categoryQueryRepository = new CategoryQueryRepository(context, transaction);
        #endregion

        #region Comment
        commentCommandRepository = new CommentCommandRepository(context, transaction);
        commentQueryRepository = new CommentQueryRepository(context, transaction);
        #endregion

        #region ProductCriteriaRS
        productCriteriaRSCommandRepository = new ProductCriteriaRSCommandRepository(context, transaction);
        productCriteriaRSQueryRepository = new ProductCriteriaRSQueryRepository(context, transaction);
        #endregion

        #region Product
        productCommandRepository = new ProductCommandRepository(context, transaction);
        productQueryRepository = new ProductQueryRepository(context, transaction);
        #endregion

        #region Store
        storeCommandRepository = new StoreCommandRepository(context, transaction);
        storeQueryRepository = new StoreQueryRepository(context, transaction);
        #endregion

        #region SustainabilityCriteria
        sustainabilityCriteriaCommandRepository = new SustainabilityCriteriaCommandRepository(context, transaction);
        sustainabilityCriteriaQueryRepository = new SustainabilityCriteriaQueryRepository(context, transaction);
        #endregion

        #region UserCampaignRS
        userCampaignRSCommandRepository = new UserCampaignRSCommandRepository(context, transaction);
        userCampaignRSQueryRepository = new UserCampaignRSQueryRepository(context, transaction);
        #endregion

        #region Settings
        settingsCommandRepository = new SettingsCommandRepository(context, transaction);
        settingsQueryRepository = new SettingsQueryRepository(context, transaction);
        #endregion

        #region Settings
        favoriteQueryRepository = new FavoriteQueryRepository(context, transaction);
        favoriteCommandRepository = new FavoriteCommandRepository(context, transaction);
        #endregion
    }
    #endregion
}
