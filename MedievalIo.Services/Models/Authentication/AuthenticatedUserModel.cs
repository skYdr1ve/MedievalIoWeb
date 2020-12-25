namespace MedievalIo.Services.Models.Authentication
{
    public class AuthenticatedUserModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
        public Wallet.Wallet Wallet { get; set; }
    }
}
