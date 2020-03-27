using Images.Data;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        private async void AddProfilePic(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Can't open album", "OK");
                return;
            }

            var image = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });

            if (image != null)
            {
                ProfilePicEntry.Source = image.Path;
            }
        }

        private async void SaveChanges(object sender, EventArgs e)
        {
            var user = (UserData)BindingContext;
            if(user.Username != null || user.Username != "")
            {
                user.Username = UsernameEntry.Text;
                var path = ProfilePicEntry.Source.ToString();
                var fixedPath = path.Substring(6);
                user.ProfilePicPath = fixedPath;

                await App.Database.SaveUserAsync(user);
            }
        }
    }
}