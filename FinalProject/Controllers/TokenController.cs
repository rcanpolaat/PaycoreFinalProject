using FinalProject.Service;
using FinalProject.Base;
using Microsoft.AspNetCore.Mvc;


namespace FinalProject
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }


        [HttpPost("Login")]
        public BaseResponse<TokenResponse> Increment([FromBody] TokenRequest request)
        {
            var response = tokenService.GenerateToken(request);
            return response;
        }


    }
}