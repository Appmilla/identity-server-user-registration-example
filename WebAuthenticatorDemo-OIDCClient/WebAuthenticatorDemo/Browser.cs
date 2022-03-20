using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.OidcClient.Browser;
using Xamarin.Essentials;

namespace WebAuthenticatorDemo
{
    public class Browser : IBrowser
    {
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            WebAuthenticatorResult authResult;

            try
            {
                authResult = await WebAuthenticator.AuthenticateAsync(new Uri(options.StartUrl), new Uri(Constants.RedirectUri));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                if (e is TaskCanceledException)
                {
                    return new BrowserResult()
                    {
                        ResultType = BrowserResultType.UserCancel
                    }; 
                }
                else
                {
                    return new BrowserResult()
                    {
                        ResultType = BrowserResultType.UnknownError
                    }; 
                }
            }
            return new BrowserResult()
            {
                Response = ParseAuthenticatorResult(authResult)
            };
        }

        string ParseAuthenticatorResult(WebAuthenticatorResult result)
        {
            string code = result?.Properties["code"];
            string scope = result?.Properties["scope"];
            string state = result?.Properties["state"];
            string sessionState = result?.Properties["session_state"];
            return $"{Constants.RedirectUri}#code={code}&scope={scope}&state={state}&session_state={sessionState}";
        }
    }
}
