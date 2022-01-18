using Poc.Infrastructure.Models;
using Poc.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poc.Test;
public partial class UserControllerUnitTest
{
    internal class MockIdentityRepository : IIdentityRepository
    {
        public static IEnumerable<UserDetailEntity> Users = new List<UserDetailEntity>
            {
                new UserDetailEntity
                {
                    Id = 1,
                    AplId = "UR1234",
                    UserName = "Rohit",
                    UserGuid = new Guid("04A95C41-E98C-1910-E9B0-E7F9F2B609CD"),
                    RoleId = 6,
                    RoleName = "Agent",
                    HasActiveRole = false
                },
                new UserDetailEntity
                {
                    Id = 2,
                    AplId = "UR1243",
                    UserName = "Rohan",
                    UserGuid = new Guid("04A95C41-E98C-1910-E9B0-E7F9F2B609DC"),
                    RoleId = 7,
                    RoleName = "Client",
                    HasActiveRole = false
                }
            };

        public UserDetailEntity? GetUserById(string guidId)
        {
            return Users.Where(user => user.UserGuid.Equals(new Guid(guidId))).FirstOrDefault();
        }

        public UserDetailEntity? GetUserByUserId(string userId)
        {
            return Users.Where(user => user.AplId == userId).FirstOrDefault();
        }
    }
}