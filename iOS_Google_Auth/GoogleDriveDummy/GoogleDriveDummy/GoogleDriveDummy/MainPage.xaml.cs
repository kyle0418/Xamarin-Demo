using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth.Presenters;
using Xamarin.Forms;

namespace GoogleDriveDummy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ConnectGoogleDrive_Clicked(object sender, EventArgs e)
        {
            var googleDriveInstance = GoogleDriveSingelton.GetInstance;
            var presenter = new OAuthLoginPresenter();
            presenter.Login(googleDriveInstance.auth);
        }
    }
}
