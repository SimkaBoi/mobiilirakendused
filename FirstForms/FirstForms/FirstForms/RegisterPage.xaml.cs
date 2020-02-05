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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            if (await AreCredentialsCorrect() == true)
            {
                Navigation.InsertPageBefore(new NotesPage(), this);
                await Navigation.PopAsync();
            }
        }

        async Task<bool> AreCredentialsCorrect()
        {
            var user = (User)BindingContext;
            if ((user.Name != null && user.Password != null) && (user.Name != "" && user.Password != ""))
            {
                await App.Database.SaveUserAsync(user);
                return true;
            }
            return false;
        }
    }
}