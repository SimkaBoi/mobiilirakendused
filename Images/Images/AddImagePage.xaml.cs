﻿using Images.Data;
using Images.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImagePage : ContentPage
    {
        public AddImagePage()
        {
            InitializeComponent();
        }

        private async void OnTakePictureButtonClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Camera can't be opened right now", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            // db stuff
            if (ImageTitle.Text == null || ImageTitle.Text == "" || file.Path == null || file.Path == "")
            {
                OnAlert("Title or image is missing!");
            }
            else
            {
                var user = (UserData)BindingContext;
                var image = new ImageData();
                image.Title = ImageTitle.Text;
                image.Path = file.Path;
                image.UserPic = user.ProfilePicPath;
                await App.Database.SaveImageAsync(image);
                OnAlert("Image has been posted!");
            }
        }

        private async void OnPickPictureButtonClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Can't open album", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });

            if (file == null)
                return;

            // db stuff
            if (ImageTitle.Text == null || ImageTitle.Text == "" || file.Path == null || file.Path == "")
            {
                OnAlert("Title or image is missing!");
            }
            else
            {
                var user = (UserData)BindingContext;
                var image = new ImageData();
                image.Title = ImageTitle.Text;
                image.Path = file.Path;
                image.UserPic = user.ProfilePicPath;
                await App.Database.SaveImageAsync(image);
                OnAlert("Image has been posted!");
            }
        }

        private async void OnAlert(string alert)
        {
            Alert.Text = alert;
        }
    }
}