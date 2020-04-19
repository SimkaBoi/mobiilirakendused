using Images.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginRegisterPage : ContentPage
    {
        public LoginRegisterPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (Username.Text == "" || Username.Text == null || Password.Text == "" || Password.Text == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Please fill all the fields!", "OK");
                return;
            }
            else
            {
                List<UserData> users = await App.Database.GetUsersAsync();
                if(users.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Wrong username or password!", "OK");
                    return;
                }
                else
                {
                    foreach(var user in users)
                    {
                        if(user.Username == Username.Text && user.Password == Password.Text)
                        {
                            var tabbedPage = new FirstTabbedPage();
                            tabbedPage.BindingContext = user;
                            await Navigation.PushAsync(tabbedPage);
                            return;
                        }
                    }
                    await Application.Current.MainPage.DisplayAlert("Alert", "Wrong username or password!", "OK");
                    return;
                }
            }
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var user = new UserData() { Username = Username.Text, Password = Password.Text };

            List<UserData> users = await App.Database.GetUsersAsync();
            if(users.Count == 0)
            {
                if (user.Username == "" || user.Username == null || user.Password == "" || user.Password == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Please fill all the fields!", "OK");
                    return;
                }
                else
                {
                    user.ProfilePicPath = "http://i.imgur.com/SqX9Qqm.jpg";
                    await App.Database.SaveUserAsync(user);
                    await Application.Current.MainPage.DisplayAlert("Alert", "User created!", "OK");
                    return;
                }
            }
            else
            {
                foreach (var name in users)
                {
                    if (user.Username == "" || user.Username == null || user.Password == "" || user.Password == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Please fill all the fields!", "OK");
                        break;
                    }
                    else if (name.Username == user.Username)
                    {
                        await Application.Current.MainPage.DisplayAlert("Alert", "Username is already taken!", "OK");
                        break;
                    }
                    else
                    {
                        user.ProfilePicPath = "http://i.imgur.com/SqX9Qqm.jpg";
                        await App.Database.SaveUserAsync(user);
                        await Application.Current.MainPage.DisplayAlert("Alert", "User created!", "OK");
                        break;
                    }
                }
            }
        }
    }
}