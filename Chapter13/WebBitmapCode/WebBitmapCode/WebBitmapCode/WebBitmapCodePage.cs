﻿using System;


using System.IO;
using System.Net;



using Xamarin.Forms;

namespace WebBitmapCode
{
    public class WebBitmapCodePage : ContentPage
    {
        public WebBitmapCodePage()
        {
            string uri = "http://developer.xamarin.com/demo/IMG_1415.JPG?width=25";

            Content = new Image
            {
                 Source = ImageSource.FromUri(new Uri(uri)),
            };
        }
    }
}
