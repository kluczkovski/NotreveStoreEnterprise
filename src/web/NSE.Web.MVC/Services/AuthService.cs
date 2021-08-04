using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NSE.Web.MVC.Extensions;
using NSE.Web.MVC.Models;

namespace NSE.Web.MVC.Services
{
    public class AuthService : Service, IAuthService 
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;

        public AuthService(HttpClient httpClient, IOptions<AppSettings> settings) 
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<UserResponseLogin> Login(UserLoginViewModel userLogin)
        {
          
            var loginContent = GetStringContent(userLogin);

            var response = await _httpClient.PostAsync($"{_settings.IdentityUrl}/api/identity/auth",
                loginContent);

            // Handler Error
            if (!HandlerErrorResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response),
                };
            }


            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }

        public async Task<UserResponseLogin> Register(UserRegisterViewModel userRegister)
        {
           
            var registerContent = GetStringContent(userRegister);

            var response = await _httpClient.PostAsync($"{_settings.IdentityUrl}/api/identity/add-user",
                registerContent);

            // Handler Error
            if (!HandlerErrorResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response),
                };
            }

            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }
    }
}
