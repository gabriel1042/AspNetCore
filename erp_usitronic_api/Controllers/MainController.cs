using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using erp_usitronic.business.interfaces;
using erp_usitronic.business.notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace erp_usitronic.api.Controllers
{
#if !DEBUG
    [Authorize("Bearer")]
#endif
    [ApiController]    
    public class MainController : ControllerBase
    {
        private readonly INotificator _notificator;

        protected MainController(INotificator notificator, 
                                    IHttpContextAccessor httpContextAccessor,
                                    IApiUserService apiUserService)
        {
            _notificator = notificator;
            #if !DEBUG
            if (!IsAuthResource(httpContextAccessor))
            {
                var token = GetToken(httpContextAccessor);
                var userName = GetUserName(token);
                var resource = GetResource(httpContextAccessor);
                var method = GetMethod(httpContextAccessor);
                if (!apiUserService.IsAuthorized(userName, resource, method))
                {
                    httpContextAccessor.HttpContext.Response.StatusCode = 401;
                    httpContextAccessor.HttpContext.Response.CompleteAsync();
                }
            }
            #endif
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyErrorInvalidModel(modelState);
            return CustomResponse();
        }

        protected void NotifyErrorInvalidModel(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }

        private JwtSecurityToken GetToken(IHttpContextAccessor httpContextAccessor)
        {
            string auth = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(auth);
        }

        private string GetUserName(JwtSecurityToken token)
        {
            return token.Claims.First().Value;
        }

        private string GetMethod(IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Request.Method.ToUpper();
        }

        private string GetResource(IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Request.RouteValues.Values.ElementAt(1).ToString().ToUpper();
        }

        private bool IsAuthResource(IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Request.RouteValues.Where(x => x.Value.ToString().ToLower() == "auth").ToList().Count > 0;
        }
    }
}