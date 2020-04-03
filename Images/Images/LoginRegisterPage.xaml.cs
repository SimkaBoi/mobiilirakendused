using Images.Data;
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
    public partial class LoginRegisterPage : ContentPage
    {
        public LoginRegisterPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if(Username.Text == "" || Username.Text == null || Password.Text == "" || Password.Text == null)
            {
                OnAlert("Please fill all the fields!");
            }
            else
            {
                List<UserData> users = await App.Database.GetUsersAsync();
                if(users.Count == 0)
                {
                    OnAlert("Wrong username or password!");
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
                        }
                        else
                        {
                            OnAlert("Wrong username or password!");
                        }
                    }
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
                    OnAlert("Please fill all the fields!");
                }
                else
                {
                    await App.Database.SaveUserAsync(user);
                    OnAlert("User created!");
                }
            }
            else
            {
                foreach (var name in users)
                {
                    if (user.Username == "" || user.Username == null || user.Password == "" || user.Password == null)
                    {
                        OnAlert("Please fill all the fields!");
                        break;
                    }
                    else if (name.Username == user.Username)
                    {
                        OnAlert("Username is already taken!");
                        break;
                    }
                    else
                    {
                        await App.Database.SaveUserAsync(user);
                        var tabbedPage = new FirstTabbedPage();
                        tabbedPage.BindingContext = user;
                        await Navigation.PushAsync(tabbedPage);
                        break;
                    }
                }
            }
        }

        private void OnAlert(string error)
        {
            Alert.Text = error;
        }
    }
}