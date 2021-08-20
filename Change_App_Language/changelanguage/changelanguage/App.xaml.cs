using changelanguage.Resource;
using System;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace changelanguage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            LocalizationResourceManager.Current.PropertyChanged += Current_PropertyChanged;
            LocalizationResourceManager.Current.Init(AppResource.ResourceManager);

            MainPage = new MainPage();
        }

        private void Current_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AppResource.Culture = LocalizationResourceManager.Current.CurrentCulture;
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
    }
}
