using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace saveimage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData("https://img2.baidu.com/it/u=2063964428,3567393925&fm=26&fmt=auto&gp=0.jpg");
            DependencyService.Get<ISavePhotoService>().SaveImageFromByte(imageBytes, "test.png");
        }
    }
}
