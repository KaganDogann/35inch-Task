using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {   //AccesToken nesnelerim
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
