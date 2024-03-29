﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using WebAuthenticatorDemo.Models;

namespace WebAuthenticatorDemo.Services
{
    public class IdentityService : IIdentityService
    {
        readonly IRequestProvider requestProvider;
        string codeVerifier;

        public IdentityService(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider;
        }

        /*
        public string CreateAuthorizationRequest()
        {
            // Create URI to authorization endpoint
            var authorizeRequest = new RequestUrl(Constants.AuthorizeUri);

            // Dictionary with values for the authorize request
            var dic = new Dictionary<string, string>();
            dic.Add("client_id", Constants.ClientId);
            dic.Add("client_secret", Constants.ClientSecret);
            dic.Add("response_type", "code id_token");
            dic.Add("scope", Constants.Scope);
            dic.Add("redirect_uri", Constants.RedirectUri);
            dic.Add("nonce", Guid.NewGuid().ToString("N"));
            dic.Add("code_challenge", CreateCodeChallenge());
            dic.Add("code_challenge_method", "S256");

            // Add CSRF token to protect against cross-site request forgery attacks.
            var currentCSRFToken = Guid.NewGuid().ToString("N");
            dic.Add("state", currentCSRFToken);

            var authorizeUri = authorizeRequest.Create(dic);
            return authorizeUri;
        }
        */
        
        public string CreateAuthorizationRequest()
        {
            // Create URI to authorization endpoint
            var authorizeRequest = new RequestUrl(Constants.AuthorizeUri);
            
            // Dictionary with values for the authorize request
            var parameters = new Parameters
            {
                {"client_id", Constants.ClientId},
                {"client_secret", Constants.ClientSecret},
                {"response_type", "code id_token"},
                //{"response_mode", "form_post"},
                {"scope", Constants.Scope},
                //{"scope", "openid profile email api"},
                {"redirect_uri", Constants.RedirectUri},
                {"nonce", Guid.NewGuid().ToString("N")}
            };
          
            // Add CSRF token to protect against cross-site request forgery attacks.
            var currentCsrfToken = Guid.NewGuid().ToString("N");
            parameters.Add("state", currentCsrfToken);

            var authorizeUri = authorizeRequest.Create(parameters);
            return authorizeUri;
        }
        
        public async Task<UserToken> GetTokenAsync(string code)
        {
            string data = string.Format("grant_type=authorization_code&code={0}&redirect_uri={1}&code_verifier={2}", code, WebUtility.UrlEncode(Constants.RedirectUri), codeVerifier);
            var token = await requestProvider.PostAsync<UserToken>(Constants.TokenUri, data, Constants.ClientId, Constants.ClientSecret);
            return token;
        }

        public async Task<string> GetAsync(string uri, string accessToken)
        {
            var response = await requestProvider.GetAsync(uri, accessToken);
            return response;
        }

        string CreateCodeChallenge()
        {
            string codeChallenge;

            codeVerifier = CryptoRandom.CreateUniqueId();
            using (var sha256 = SHA256.Create())
            {
                var challengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(codeVerifier));
                codeChallenge = Base64Url.Encode(challengeBytes);
            }
            return codeChallenge;
        }
    }
}
