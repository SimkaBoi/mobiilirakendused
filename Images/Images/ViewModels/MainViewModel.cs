using Images.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Images.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Images = new ObservableCollection<ImageData>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<ImageData> _images;
        public ObservableCollection<ImageData> Images
        {
            get
            {
                return _images;
            }

            set
            {
                if (_images != value)
                {
                    _images = value;
                    OnPropertyChanged(nameof(Images));
                }
            }

        }

        public async void GetImages()
        {
            Images.Clear();
            var images = await App.Database.GetImagesAsync();

            foreach(var image in images)
            {
                Images.Add(image);
            }
        }
    }
}