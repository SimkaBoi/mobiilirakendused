using Images.Data;
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

namespace Images
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetImages();
        }

        private async void GetImages()
        {
            List<ImageData> Images = await App.Database.GetImagesAsync();
            pictureList.ItemsSource = Images;
        }

        private async void SingleTap(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            var image = stackLayout.BindingContext as ImageData;
            var user = (UserData)BindingContext;
            var userAndPostId = new PostAndUserIdModel() { UserId = user.Id, PostId = image.Id };

            await Navigation.PushAsync(new ImageDetailsPage
            {
                BindingContext = userAndPostId,
            });
        }

        private async void DoubleTap(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            var image = stackLayout.BindingContext as ImageData;
            var user = (UserData)BindingContext;
            List<LikeData> likes = await App.Database.GetLikesAsync();
            foreach(var like in likes)
            {
                if(like.UserId == user.Id && like.PostId == image.Id)
                {
                    await App.Database.DeleteLikeAsync(like);
                    image.Likes--;
                    await App.Database.SaveImageAsync(image);
                    return;
                }
            }
            LikeData addLike = new LikeData() { Id = 0, PostId = image.Id, UserId = user.Id };
            await App.Database.SaveLikeAsync(addLike);
            image.Likes++;
            await App.Database.SaveImageAsync(image);
        }
    }
}
