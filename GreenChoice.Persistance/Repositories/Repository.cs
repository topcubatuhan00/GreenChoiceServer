﻿using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.Repositories;

public abstract class Repository
{
    protected SqlConnection _context;
    protected SqlTransaction _transaction;

    protected SqlCommand CreateCommand(string query)
    {
        return new SqlCommand(query, _context, _transaction);
    }
}
