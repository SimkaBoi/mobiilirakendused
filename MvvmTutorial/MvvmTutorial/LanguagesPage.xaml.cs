using MvvmTutorial.Models;
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
    public partial class LanguagesPage : ContentPage
    {
        public LanguagesPage()
        {
            InitializeComponent();
            LanguageList.ItemsSource = new List<LanguageModel>()
            {    
            };
        }
    }
}