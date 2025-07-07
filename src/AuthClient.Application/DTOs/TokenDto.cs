using System;

namespace AuthClient.Application.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime ExpiresUtc { get; set; }
    }
}
