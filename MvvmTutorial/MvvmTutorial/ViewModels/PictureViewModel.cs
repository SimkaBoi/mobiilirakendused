using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MvvmTutorial.ViewModels
{
    public class PictureViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public PictureViewModel()
        {

        }
    }
}
