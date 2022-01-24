using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Poc.Core;
using Poc.Core.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Poc.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    //[ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService service;
        private readonly ILogger<UserController> logger;

        public UserController(IIdentityService service, ILogger<UserController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [Authorize]
        [HttpGet("userId/{id}")]
        [EnableCors("AllowAll")]
        public ActionResult<BaseResponse<User>> GetUserByUserId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                this.logger.LogError("Id is null or empty");
                return BadRequest("Id is null or empty");
            }

            var user = this.service.GetUserByUserId(id);
            if (user is null)
            {
                this.logger.LogError("User with {id} does not exist", id);
                return NotFound("User with provided id does not exist");
            }
            var response = new BaseResponse<User>(user, HttpStatusCode.OK);
            return Ok(response);
        }

        [HttpGet("users/{id}")]
        public ActionResult<BaseResponse<string>> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                this.logger.LogError("Id is null or empty");
                return BadRequest("Id is null or empty");
            }

            var user = this.service.GetUserById(id);
            if (user is null)
            {
                this.logger.LogError("User with {id} does not exist", id);
                return NotFound("User with provided id does not exist");
            }

            var result = JsonSerializer.Serialize(user);
            var bytes = Encoding.UTF8.GetBytes(result);
            var base64EncodedString = Convert.ToBase64String(bytes);

            var response = new BaseResponse<string>(base64EncodedString, HttpStatusCode.OK);
            return Ok(response);
        }
    }
}