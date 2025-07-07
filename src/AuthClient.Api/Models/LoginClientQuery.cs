namespace AuthClient.Api.Models
{
    public class LoginClientQuery
    {
        public string UserIdentifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
