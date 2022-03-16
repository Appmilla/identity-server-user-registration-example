namespace WebAuthenticatorDemo
{
    /*
    public static class Constants
    {
        public static string AuthorityUri = "https://demo.identityserver.io";
        public static string AuthorizeUri = "https://demo.identityserver.io/connect/authorize";
        public static string TokenUri = "https://demo.identityserver.io/connect/token";
        public static string RedirectUri = "io.identitymodel.native://callback";
        public static string ApiUri = "https://demo.identityserver.io/api/";
        public static string ClientId = "native.hybrid";
        public static string ClientSecret = "xoxo";
        public static string Scope = "openid profile api";
    }
    */
    public static class Constants
    {
        public static string AuthorityUri = "https://identityserverhost20220225150440.azurewebsites.net";
        public static string AuthorizeUri = "https://identityserverhost20220225150440.azurewebsites.net/connect/authorize";
        public static string TokenUri = "https://identityserverhost20220225150440.azurewebsites.net/connect/token";
        public static string RedirectUri = "io.identitymodel.native://callback";
        public static string ApiUri = "https://api20220228203615.azurewebsites.net/";
        public static string ClientId => "interactive.confidential.hybrid";
        
        public static string ClientSecret = "secret";
        public static string Scope => "openid profile email api1 offline_access";
    }
}
