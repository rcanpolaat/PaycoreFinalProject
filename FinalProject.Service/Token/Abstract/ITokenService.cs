using FinalProject.Base;
using FinalProject.Data;
using FinalProject.Dto;

namespace FinalProject.Service
{
    public interface ITokenService
    {
        BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}