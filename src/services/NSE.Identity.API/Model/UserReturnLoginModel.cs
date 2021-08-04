using System;
namespace NSE.Identity.API.Model
{
    public class UserReturnLoginModel
    {
        public string AccessToken { get; set; }

        public double ExpireIn { get; set; }

        public UserToken  UserToken { get; set; }
    }
}
