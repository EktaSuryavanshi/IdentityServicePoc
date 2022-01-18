using Poc.Infrastructure.Data;
using Poc.Infrastructure.Models;

namespace Poc.Infrastructure.Repositories
{
    internal class IdentityRepository : IIdentityRepository
    {
        private readonly DataContext dataContext;

        public IdentityRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public UserDetailEntity? GetUserById(string guidId)
        {
            var user = this.dataContext.UserDetails.Where(c => c.UserGuid.Equals(guidId)).FirstOrDefault();
            return user;
        }

        public UserDetailEntity? GetUserByUserId(string userId)
        {
            var user = this.dataContext.UserDetails.Where(c => c.AplId == userId).FirstOrDefault();
            return user;
        }
    }
}
