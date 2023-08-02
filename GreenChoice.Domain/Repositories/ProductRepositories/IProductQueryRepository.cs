﻿using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Helpers;
using GreenChoice.Domain.Models.HelperModels;

namespace GreenChoice.Domain.Repositories.ProductRepositories;

public interface IProductQueryRepository
{
    PaginationHelper<Product> GetAll(PaginationRequest request);
    Task<Product> GetById(int Id);
}
