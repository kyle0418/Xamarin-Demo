using Foundation;
using saveimage.iOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SavePhotoService))]
namespace saveimage.iOS
{
    class SavePhotoService : ISavePhotoService
    {

        public void SaveImageFromByte(byte[] imageByte, string fileName)
        {
            var imageData = new UIImage(NSData.FromArray(imageByte));
            imageData.SaveToPhotosAlbum((image, error) =>
            {
                    //you can retrieve the saved UI Image as well if needed using  
                    //var i = image as UIImage;  
                    if (error != null)
                {
                    Console.WriteLine(error.ToString());
                }
            });
        }
    }
}