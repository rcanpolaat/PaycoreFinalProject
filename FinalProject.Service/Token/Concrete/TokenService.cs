using AutoMapper;
using FinalProject.Base;
using FinalProject.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using FinalProject.Dto;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Security.Principal;

namespace FinalProject.Service
{
    public class TokenService : ITokenService
    {

        protected readonly ISession session;
        protected readonly IHibernateRepository<User> hibernateRepository;
        private readonly JwtConfig jwtConfig;

        public TokenService(ISession session, IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.session = session;
            this.jwtConfig = jwtConfig.CurrentValue;
            hibernateRepository = new HibernateRepository<User>(session);
        }



        public BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest)
        {
            try
            {
                if (tokenRequest is null)
                {
                    return new BaseResponse<TokenResponse>("Please enter valid informations.");
                }

                var user = hibernateRepository.Where(x => x.Email.Equals(tokenRequest.Email)).FirstOrDefault();
                if (user is null)
                {
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }

                if (!user.Password.Equals(tokenRequest.Password))
                {
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }

                DateTime now = DateTime.UtcNow;
                string token = GetToken(user, now);

                try
                {
                    user.LastActivity = now;

                    hibernateRepository.BeginTransaction();
                    hibernateRepository.Update(user);
                    hibernateRepository.Commit();
                    hibernateRepository.CloseTransaction();
                }
                catch (Exception ex)
                {
                    Log.Error("GenerateToken Update Account LastActivity:", ex);
                    hibernateRepository.Rollback();
                    hibernateRepository.CloseTransaction();
                }

                TokenResponse tokenResponse = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Name = user.Email,
                    SessionTimeInSecond = jwtConfig.AccessTokenExpiration * 60
                };

                return new BaseResponse<TokenResponse>(tokenResponse);
            }
            catch (Exception ex)
            {
                Log.Error("GenerateToken :", ex);
                return new BaseResponse<TokenResponse>("GenerateToken Error");
            }
        }


        private string GetToken(User user, DateTime date)
        {
            Claim[] claims = GetClaims(user);
            byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: date.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private Claim[] GetClaims(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Email",user.Email)
            };

            return claims;
        }
    }
}