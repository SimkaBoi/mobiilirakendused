using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ICommand LoginCommand { get; private set; }
        private async void OnLoginButtonClickedCommand()
        {

        }

        public ICommand RegisterCommand { get; private set; }
        private async void OnRegisterButtonClickedCommand()
        {
            if (await AreCredentialsCorrect() == true)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }

        public async Task<bool> AreCredentialsCorrect()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
