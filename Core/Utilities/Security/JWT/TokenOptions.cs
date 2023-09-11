namespace Core.Utilities.Security.JWT
{
    //token options bizim appsettings.jsondaki verileri
    //buraya aktarmamız için oluşturduğumuz bir class
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
