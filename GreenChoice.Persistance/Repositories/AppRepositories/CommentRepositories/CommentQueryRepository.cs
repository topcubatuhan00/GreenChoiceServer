using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;
using GreenChoice.Domain.Repositories.CommentRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories.AppRepositories.CommentRepositories;

public class CommentQueryRepository : Repository, ICommentQueryRepository
{
    #region Ctor
    public CommentQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion
    public PaginationHelper<Comment> GetAll(PaginationRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<Comment> GetById(int Id)
    {
        throw new NotImplementedException();
    }
}
