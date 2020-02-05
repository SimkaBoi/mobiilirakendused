using FirstForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if(await AreCredentialsCorrect() == true)
            {
                Navigation.InsertPageBefore(new NotesPage(), this);
                await Navigation.PopAsync();
            }
        }
        async Task<bool> AreCredentialsCorrect()
        {
            var user = (User)BindingContext;
            List<User> users = await App.Database.GetUsersAsync();
            var name = users.Where(x => x.Name == user.Name).FirstOrDefault();
            if (name == null)
            {
                return false;
            }
            else if(user.Name == name.Name && user.Password == name.Password)
            {
                return true;
            }
            return false;
        }
    }
}