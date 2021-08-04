using System;
using System.Threading.Tasks;
using NSE.Web.MVC.Models;

namespace NSE.Web.MVC.Services
{
    public interface IAuthService
    {
        Task<UserResponseLogin> Login(UserLoginViewModel userLogin);

        Task<UserResponseLogin> Register(UserRegisterViewModel userRegister);
    }
}
