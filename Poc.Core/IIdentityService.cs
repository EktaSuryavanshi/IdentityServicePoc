using Poc.Core.Models;

namespace Poc.Core
{
    public interface IIdentityService
    {
        public User? GetUserByUserId(string userId);

        public User? GetUserById(string guidId);
    }
}