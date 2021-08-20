﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoogleDriveDummy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            // DOES NOT FIRE EITHER
            base.OnAppLinkRequestReceived(uri);
        }
    }
}
