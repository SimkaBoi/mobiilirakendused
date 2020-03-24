using Images.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Images.ViewModels
{
    public class LoginRegisterViewModel : INotifyPropertyChanged
    {
        public LoginRegisterViewModel()
        {
            LoginCommand = new Command(OnLoginButtonClickedCommand);
            RegisterCommand = new Command(OnRegisterButtonClickedCommand);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand LoginCommand { get; private set; }
        private async void OnLoginButtonClickedCommand()
        {
            if (await AreLoginCredentialsCorrect() == true)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }

        public async Task<bool> AreLoginCredentialsCorrect()
        {
            var user = new UserData() { Username = Name, Password = Password };
            List<UserData> users = await App.Database.GetUsersAsync();
            var name = users.Where(x => x.Username == user.Username).FirstOrDefault();
            if (name == null)
            {
                return false;
            }
            else if (user.Username == name.Username && user.Password == name.Password)
            {
                return true;
            }
            return false;
        }

        public ICommand RegisterCommand { get; private set; }
        private async void OnRegisterButtonClickedCommand()
        {
            if (await IsUsernameTaken() == false && await AreRegisterCredentialsCorrect() == true)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }

        public async Task<bool> AreRegisterCredentialsCorrect()
        {
            var user = new UserData() { Username = Name, Password = Password };
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                await App.Database.SaveUserAsync(user);
                return true;
            }
            return false;
        }

        public async Task<bool> IsUsernameTaken()
        {
            var user = new UserData() { Username = Name, Password = Password };
            List<UserData> users = await App.Database.GetUsersAsync();
            foreach(var name in users)
            {
                if(name.Username == user.Username)
                {
                    return true;
                }
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
