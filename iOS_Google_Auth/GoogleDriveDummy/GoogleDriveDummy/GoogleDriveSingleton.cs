using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;


namespace GoogleDriveDummy
{
    public class GoogleDriveSingelton
    {
        private static GoogleDriveSingelton globalInstance = null;
        public string index;
        public OAuth2Authenticator auth;
        public DriveService driveService;
        private GoogleDriveSingelton()
        {
            AuthGoogleDrive();
            index = "abc";
        }
        public static GoogleDriveSingelton GetInstance
        {
            get
            {
                if (globalInstance == null)
                {
                    globalInstance = new GoogleDriveSingelton();
                }
                return globalInstance;
            }
        }


        private void AuthGoogleDrive()
        {
            auth = new OAuth2Authenticator(
              GoogleConfig.clientId,
              string.Empty,
              GoogleConfig.scope,
              new Uri("https://accounts.google.com/o/oauth2/auth"),
              new Uri(GoogleConfig.redirectUrl),
              new Uri("https://www.googleapis.com/oauth2/v4/token"),
              isUsingNativeUI: true);

            //auth = new OAuth2Authenticator(GoogleConfig.clientId, string.Empty, "email", new Uri("https://accounts.google.com/o/oauth2/v2/auth"), new Uri(GoogleConfig.redirectUrl), new Uri("https://www.googleapis.com/oauth2/v4/token"), isUsingNativeUI: true);


            //AuthenticatorHelper.OAuth2Authenticator = auth;

            auth.Completed += Auth_Completed;
            auth.Error += Auth_Error;
        }

        private async void Auth_Error(object sender, AuthenticatorErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request("GET", new Uri("https://www.googleapis.com/oauth2/v2/userinfo"), null, e.Account);
                var response = await request.GetResponseAsync();
                string str = await response.GetResponseTextAsync();

                Console.WriteLine("+++++++++++++" + str + "+++++++++++++++++++++++++");
                //var token = new GoogleOAuthToken
                //{
                //    TokenType = e.Account.Properties["token_type"],
                //    AccessToken = e.Account.Properties["access_token"]
                //};


                //            var initializer = new GoogleAuthorizationCodeFlow.Initializer
                //            {
                //                ClientSecrets = new Google.Apis.Auth.OAuth2.ClientSecrets()
                //                {
                //                    ClientId = GoogleConfig.clientId,
                //                }
                //            };
                //            initializer.Scopes = new[] { GoogleConfig.scope
                //};
                //            initializer.DataStore = new FileDataStore("Google.Apis.Auth");
                //            var flow = new GoogleAuthorizationCodeFlow(initializer);
                //            var user = "DriveTest";
                //            var token = new TokenResponse()
                //            {
                //                AccessToken = e.Account.Properties["access_token"],
                //                ExpiresInSeconds = Convert.ToInt64(e.Account.Properties["expires_in"]),
                //                RefreshToken = e.Account.Properties["refresh_token"],
                //                Scope = e.Account.Properties["scope"],
                //                TokenType = e.Account.Properties["token_type"]
                //            };


                //            UserCredential userCredential = new UserCredential(flow, user, token);
                //            driveService = new DriveService(new BaseClientService.Initializer()
                //            {
                //                HttpClientInitializer = userCredential,
                //                ApplicationName = "XamarinDriveTest",
                //            });

                //Application.Current.MainPage = new NavigationPage(new views.GoogleServicesPage());
                //Application.Current.MainPage = new NavigationPage(new views.FileExplorer());
            }
        }
    }
    public static class AuthenticatorHelper
    {
        public static OAuth2Authenticator OAuth2Authenticator { get; set; }
    }
}
