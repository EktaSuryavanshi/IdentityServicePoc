using Poc.Infrastructure.Models;

namespace Poc.Infrastructure.Repositories;

public interface IIdentityRepository
{
    public UserDetailEntity? GetUserById(string guidId);

    public UserDetailEntity? GetUserByUserId(string userId);
}