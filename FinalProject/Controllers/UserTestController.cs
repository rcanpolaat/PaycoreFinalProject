using FinalProject.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FinalProject
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthTestController : ControllerBase
    {
        public AuthTestController()
        {

        }

        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "NoToken";
        }

        [Authorize]
        [HttpGet("WithAuthorize")]
        public string WithAuthorize()
        {
            return "WithAuthorize";
        } 

    }
}