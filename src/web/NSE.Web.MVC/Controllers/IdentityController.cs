using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.Web.MVC.Models;
using NSE.Web.MVC.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NSE.Web.MVC.Controllers
{
    public class IdentityController : BaseController
    {
        private readonly IAuthService _authenticationService;

        public IdentityController(IAuthService authentication)
        {
            _authenticationService = authentication;
        }
    
        [HttpGet]
        [Route("new-account")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegister)
        {
            if (!ModelState.IsValid) return View(userRegister);

            // API Register
            var response = await _authenticationService.Register(userRegister);

            if (ResponseHasErrors(response.ResponseResult)) return View(userRegister);

            // Doing Login
            await DoingLogin(response);

            // Log in User
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Route("login")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin, string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(userLogin);

            // API Login
            var response = await _authenticationService.Login(userLogin);

            if (ResponseHasErrors(response.ResponseResult)) return View(userLogin);
             
            // Doing Login
            await DoingLogin(response);

            // Log in User
            if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

            return LocalRedirect(returnUrl);
        }


        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        private async Task DoingLogin(UserResponseLogin response)
        {
            var token = GetFormatedToken(response.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", response.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }


        private static JwtSecurityToken GetFormatedToken(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
