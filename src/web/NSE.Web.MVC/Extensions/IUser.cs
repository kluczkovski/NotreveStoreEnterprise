using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace NSE.Web.MVC.Extensions
{
    public interface IUser
    {
        string Name { get; }

        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        bool IsAutenticated();
        bool HasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();

    }


    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor httpContext)
        {
            _accessor = httpContext;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;


        public Guid GetUserId()
        {
            return IsAutenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty ;
        }


        public string GetUserEmail()
        {
            return IsAutenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }


        public string GetUserToken()
        {
            return  IsAutenticated() ? _accessor.HttpContext.User.GetUserToken() : "";
        }


        public bool IsAutenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }


        public bool HasRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }


        public IEnumerable<Claim> GetClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _accessor.HttpContext;
        }

    }


    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("sub");
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("email");
            return claim?.Value;
        }

        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("JWT");
            return claim?.Value;
        }
    }
}
