using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;

namespace GoogleDriveDummy.Droid
{
    [Activity(Label = "ActivityCustomUrlSchemeInterceptor", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataSchemes = new[] { "com.companyname.googledrive" }, DataPath = "/oauth2redirect")]
    public class ActivityCustomUrlSchemeInterceptor : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Android.Net.Uri uri_android = Intent.Data;
            CustomTabsConfiguration.CustomTabsClosingMessage = null;
            var uri = new Uri(Intent.Data.ToString());
            AuthenticatorHelper.OAuth2Authenticator.OnPageLoading(uri);
            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);
            this.Finish();
            return;
        }
    }
}