using System;
using System.Collections.Generic;
using System.Text;

namespace TokenJwt.Dto
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public TokenDto() { }

        public TokenDto(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
