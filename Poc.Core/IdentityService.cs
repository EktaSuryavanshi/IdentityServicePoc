using AutoMapper;
using Poc.Core.Models;
using Poc.Infrastructure.Repositories;

namespace Poc.Core;
public class IdentityService : IIdentityService
{
    private readonly IIdentityRepository repository;
    private readonly IMapper mapper;

    public IdentityService(IIdentityRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public User? GetUserById(string guidId)
    {
        var userDetail = this.repository.GetUserById(guidId);
        if (userDetail is null)
        {
            return null;
        }
        User user = this.mapper.Map<User>(userDetail);
        return user;
    }

    public User? GetUserByUserId(string userId)
    {
        var userDetail = this.repository.GetUserByUserId(userId);
        if (userDetail is null)
        {
            return null;
        }

        User user = this.mapper.Map<User>(userDetail);
        return user;
    }
}
