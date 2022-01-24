using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Poc.Api.Controllers;
using Poc.Core;
using Poc.Core.Models;
using Poc.Infrastructure.Models;
using Poc.Infrastructure.Repositories;
using Xunit;

namespace Poc.Test;
public partial class UserControllerUnitTest
{
    UserController controller;
    IIdentityService service;
    IIdentityRepository repository;

    public UserControllerUnitTest()
    {
        var mapper = new Mock<IMapper>();
        mapper.Setup(x => x.Map<User>(It.IsAny<UserDetailEntity>()))
              .Returns((UserDetailEntity source) =>
              {
                  User user = new()
                  {
                      AplId = source.AplId,
                      HasActiveRole = source.HasActiveRole,
                      RoleId = source.RoleId,
                      RoleName = source.RoleName,
                      UserGuid = source.UserGuid,
                      UserName = source.UserName,
                  };
                  return user;
              });
        repository = new MockIdentityRepository();
        service = new IdentityService(repository, mapper.Object);
        controller = new UserController(service, new NullLogger<UserController>());
    }

    [Fact]
    public void ValidUserId()
    {
        var userId = "UR1234";
        var result = controller.GetUserByUserId(userId);
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void InvalidUserId()
    {
        var userId = "UR1";
        var result = controller.GetUserByUserId(userId);
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public void EmptyUserId()
    {
        string userId = string.Empty;
        var result = controller.GetUserByUserId(userId);
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void ValidGuidId()
    {
        var guidId = "04A95C41-E98C-1910-E9B0-E7F9F2B609CD";
        var result = controller.GetUserById(guidId);
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void InvalidGuidId()
    {
        var guidId = "01234567-1234-1234-1234-123456789123";
        var result = controller.GetUserById(guidId);
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public void EmptyGuidId()
    {
        var guidId = string.Empty;
        var result = controller.GetUserById(guidId);
        Assert.IsType<BadRequestObjectResult>(result.Result);
    }
}