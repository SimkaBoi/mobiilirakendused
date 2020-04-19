using Images.Data;
using Images.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using Images.ViewModels;

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
            (this.BindingContext as MainViewModel)?.GetImages();
        }

        private async void DoubleTap(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;
            var image = stackLayout.BindingContext as ImageData;
            var user = Parent.BindingContext as UserData;
            List<LikeData> likes = await App.Database.GetLikesAsync();
            foreach(var like in likes)
            {
                if(like.UserId == user.Id && like.PostId == image.Id)
                {
                    await App.Database.DeleteLikeAsync(like);
                    image.Likes--;
                    await App.Database.SaveImageAsync(image);
                    (this.BindingContext as MainViewModel)?.GetImages();
                    return;
                }
            }
            LikeData addLike = new LikeData() { Id = 0, PostId = image.Id, UserId = user.Id };
            await App.Database.SaveLikeAsync(addLike);
            image.Likes++;
            await App.Database.SaveImageAsync(image);
            (this.BindingContext as MainViewModel)?.GetImages();
        }
        
        private async void Comments_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var image = button.BindingContext as ImageData;
            var user = Parent.BindingContext as UserData;
            var userAndPostId = new PostAndUserDataModel() { UserId = user.Id, PostId = image.Id, UserName = user.Username, ProfilePicPath = user.ProfilePicPath };

            await Navigation.PushAsync(new ImageDetailsPage
            {
                BindingContext = userAndPostId,
            });
        }
    }
}
