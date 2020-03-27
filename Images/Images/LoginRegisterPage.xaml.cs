using Images.Data;
using Images.ViewModels;
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
            var user = new UserData() { Username = Username.Text, Password = Password.Text };
            List<UserData> users = await App.Database.GetUsersAsync();
            if(user.Username == null || user.Password == null || user.Username == "" || user.Password == "")
            {
                OnError("Please fill all the fields!");
            }
            else
            {
                var name = users.Where(x => x.Username == user.Username).FirstOrDefault();
                if (name == null)
                {
                    OnError("Wrong username or password!");
                }
                else if (user.Username == name.Username && user.Password == name.Password)
                {
                    var tabbedPage = new FirstTabbedPage();
                    tabbedPage.BindingContext = user;
                    await Navigation.PushAsync(tabbedPage);
                }
                else
                {
                    OnError("Wrong username or password!");
                }
            }
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var user = new UserData() { Username = Username.Text, Password = Password.Text };
            List<UserData> users = await App.Database.GetUsersAsync();
            foreach (var name in users)
            {
                if(user.Username == "" || user.Username == null || user.Password == "" ||user.Password == null)
                {
                    OnError("Please fill all the fields!");
                    break;
                }
                else if (name.Username == user.Username)
                {
                    OnError("Username is already taken!");
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

        private async void OnError(string error)
        {
            Error.Text = error;
        }
    }
}