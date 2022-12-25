namespace Models.IdentityModels
{
    public class TwoFactorAuthenticationViewModel
    {
        public string Code { get; set; }

        //used to register / signup
        public string Token { get; set; }
        public string QRCodeUrl { get; set; }
    }
}