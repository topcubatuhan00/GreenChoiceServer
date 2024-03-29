﻿using GreenChoice.Domain.Entities;

namespace GreenChoice.Domain.Repositories.UserRepositories;

public interface IUserCommandRepository
{
    Task AddAsync(User model);
    Task AddRangeAsync(IEnumerable<User> model);
    void Update(User entity);
    void UpdatePassword(User entity);
    void UpdateRange(IEnumerable<User> model);
    Task RemoveById(int id);
    void Remove(User entity);
    void RemoveRange(IEnumerable<User> model);
}
