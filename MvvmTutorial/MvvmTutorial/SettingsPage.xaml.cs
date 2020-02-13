using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmTutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            LanguageButton.Clicked += LanguageButton_Clicked;
        }

        private async void LanguageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LanguagesPage());
        }
    }
}