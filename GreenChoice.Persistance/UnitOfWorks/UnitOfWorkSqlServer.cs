using GreenChoice.Domain.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace GreenChoice.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServer : IUnitOfWork
{
    #region Fields
    private readonly IConfiguration _configuration;
    #endregion

    #region Ctor
    public UnitOfWorkSqlServer(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    #endregion

    #region Methods
    
    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("GreenChoiceConnection");
    }
    
    public IUnitOfWorkAdapter Create()
    {
        var connectionString = GetConnectionString();
        return new UnitOfWorkSqlServerAdapter(connectionString);
    }
    #endregion
}
