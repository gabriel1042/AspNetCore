using erp_usitronic.api.Authentication;
using erp_usitronic.api.Controllers;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace erp_usitronic.api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : MainController
    {
        public AuthController(INotificator notificator,
                                IHttpContextAccessor httpContextAccessor,
                                IApiUserService apiUserService) : base(notificator, httpContextAccessor, apiUserService)
        {

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ApiToken>> PostAsync(
            [FromBody] ApiUser apiUser,
            [FromServices, NotNull] IApiUserRepository apiUserRepository,
            [FromServices, NotNull] IApiTokenRepository apiTokenRepository,
            [FromServices, NotNull] SigningConfigurations signingConfigurations,
            [FromServices, NotNull] TokenConfigurations tokenConfigurations)
        {
            if (apiUser == null) throw new ArgumentNullException(nameof(apiUser));
            if (apiUserRepository == null) throw new ArgumentNullException(nameof(apiUserRepository));
            if (signingConfigurations == null) throw new ArgumentNullException(nameof(signingConfigurations));
            if (tokenConfigurations == null) throw new ArgumentNullException(nameof(tokenConfigurations));

            var validCredentials = false;
            if (!string.IsNullOrWhiteSpace(apiUser.Name))
            {
                var users = apiUserRepository.FindAsNoTracking(x => x.Name == apiUser.Name).Result;
                var user = users.Count > 0 ? users.First() : null;
                validCredentials = user != null &&
                    apiUser.Name == user.Name &&
                    apiUser.AccessKey == user.AccessKey;
            }

            if (validCredentials)
            {
                var identity = new ClaimsIdentity(
                    new GenericIdentity(apiUser.Name, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
                    }
                );

                var CreationDate = DateTime.Now;
                var ExpirationDate = CreationDate +
                                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = CreationDate,
                    Expires = ExpirationDate
                });
                var token = handler.WriteToken(securityToken);

                ApiToken apiToken = new ApiToken
                {
                    Created = CreationDate,
                    Expiration = ExpirationDate,
                    AccessToken = token
                };
                await apiTokenRepository.Add(apiToken);
                    
                var removeDate = DateTime.Now.AddDays(-10);
                await apiTokenRepository.RemoveMany(x => x.Expiration <= removeDate);
                return apiToken;
            }

            NotifyError("As credenciais informadas não são válidas.");
            return CustomResponse();
        }
    }
}
