# identity-server-user-registration-example
IdentityServer v6 with ASP.Net Core Identity for user registration and focus on mobile client using PKCE OAuth 2.0 flow.

An overview video with a demo can be found at https://youtu.be/U4WXru88NCQ

Various clients are included which were used at different stages of development:-

Console_Client - used validate IdentityServer and API locally

WebClient - followed the quickstart using OIDC

WebAuthenticatorDemo - basic mobile app without PKCE - this is a stepping stone and not the recommended best practice

NetCoreConsole - prove out the PKCE flow locally

WebAuthenticatorDemo-OIDCClient - the recommended best practice for mobile apps

Folders:-

Api - Asp.Net Api exposing WeatherForecast endpoint secured by the IdentityServer

Console_Client - Used to test the Api during initial development

IdentityServerHost - the IdentityServer. Note by design the 'Click here to see the claims for your current session' only works when running locally.

NetCoreConsole - login using PKCE, call Api and/or refresh the token. Uses pretty much the same server client config as the Xamarin PKCE with different redirect urls. Note when running this it will throw an exception F5 past this and you should get to the login.

WebAuthenticatorDemo - Xamarin.Forms app using Hybrid flow and secret like another app we might be familiar with

WebAuthenticatorDemo-OIDCClient - Xamarin.Forms app using PKCE and IdentityModel OIDC Client library

WebClient - Asp.Net MVC app from the quickstart, log in with OIDC, redirect and display the claims info. Used as a stepping stone to prove the Identity Server works locally before publishing to Azure.

Steps to recreate can be found in the Word doc DuendeIdentityServerAndAspNetIdentity.docx
