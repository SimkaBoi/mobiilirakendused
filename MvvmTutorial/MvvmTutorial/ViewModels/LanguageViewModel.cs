using MvvmTutorial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MvvmTutorial.ViewModels
{
    public class LanguageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public LanguageViewModel()
        {
            Languages = new List<Language> { new Language { Name = "Eesti", ShortName = "EST" },
                                             new Language { Name = "Saksa", ShortName = "GER" },
                                             new Language { Name = "Vene", ShortName = "RUS" },
                                             new Language { Name = "Läti", ShortName = "LAT" },
                                             new Language { Name = "Soome", ShortName = "FIN" },
            };
        }
        private List<Language> _languages;
        public List<Language> Languages
        {
            get { return _languages; }
            set
            {
                if (_languages != value)
                {
                    _languages = value;
                    OnPropertyChanged(nameof(Languages));
                }
            }
        }

        private Language _selectedLanguage = new Language();
        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged(nameof(SelectedLanguage));
                }
            }
        }
    }
}
