# IdentityServer User Registration example API and clients including a PKCE Mobile App Client

A template to create an IdentityServer v6 with ASP.Net Core Identity for user registration can be found at https://github.com/Appmilla/identity-server-user-registration-template

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

NetCoreConsole - login using PKCE, call Api and/or refresh the token. Uses pretty much the same server client config as the Xamarin PKCE with different redirect urls. Note when running this it will throw an exception F5 past this and you should get to the login.

WebAuthenticatorDemo - Xamarin.Forms app using Hybrid flow and secret - update the Constants to point to url's you have published locations of the IdentityServer and API.

WebAuthenticatorDemo-OIDCClient - Xamarin.Forms app using PKCE and IdentityModel OIDC Client library - update the Constants to point to url's you have published locations of the IdentityServer and API.

Please note when using the IdentityModel.OidcClient you may bump into this problem https://github.com/IdentityModel/IdentityModel/issues/408

The Xamarin apps WebAuthenticatorDemo & WebAuthenticatorDemo-OIDCClient started life as examples from David Britch https://www.davidbritch.com/2020/04/authentication-from-xamarinforms-app.html

I had to workaround an issue https://github.com/IdentityModel/IdentityModel/issues/408 after upgrading to IdentityModel.OidcClient v5.0.0 so it's worth being aware of the additonal references which need to be added to the iOS project file.

WebClient - Asp.Net MVC app from the quickstart, log in with OIDC, redirect and display the claims info. Used as a stepping stone to prove the Identity Server works locally before publishing to Azure.

Steps to recreate can be found in the Word doc DuendeIdentityServerAndAspNetIdentity.docx

To create the Identity Server follow the steps in the ReadMe https://github.com/Appmilla/identity-server-user-registration-template#readme
