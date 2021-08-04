using System.Collections.Generic;

namespace NSE.Identity.API.Model
{
    public class UserToken
    {
        public string Id { get; set; }

        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }
}