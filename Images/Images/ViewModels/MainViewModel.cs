using Images.Data;
using Images.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Images.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Images = new ObservableCollection<ImageWithInfo>();
            TakePictureCommand = new Command(OnTakePictureCommand);
            PickPictureCommand = new Command(OnPickPictureCommand);
            UpdateList();
        }

        private ObservableCollection<ImageWithInfo> _images;
        public ObservableCollection<ImageWithInfo> Images
        {
            get { return _images; }
            set
            {
                if (_images != value)
                {
                    _images = value;
                    OnPropertyChanged(nameof(Images));
                }
            }
        }
        public ICommand TakePictureCommand { get; private set; }

        private async void OnTakePictureCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Camera can't be opened right now", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            // db stuff

            var dbImage = new ImageData();
            dbImage.Title = "Title";
            dbImage.Path = file.Path;
            await App.Database.SaveImageAsync(dbImage);
            AddToList();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand PickPictureCommand { get; private set; }

        private async void OnPickPictureCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "Can't open album", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });

            if (file == null)
                return;

            // db stuff

            var dbImage = new ImageData();
            dbImage.Title = "Title";
            dbImage.Path = file.Path.ToString();
            await App.Database.SaveImageAsync(dbImage);
            AddToList();
        }

        private async void AddToList()
        {
            List<ImageData> images = await App.Database.GetImagesAsync();
            var image = images[images.Count - 1];
            var imageModel = new ImageWithInfo();
            imageModel.Name = image.Title;
            imageModel.Source = ImageSource.FromFile(image.Path);
            Images.Add(imageModel);
        }

        private async void UpdateList()
        {
            List<ImageData> images = await App.Database.GetImagesAsync();
            if(images.Count == 0)
            {
                return;
            }
            else
            {
                foreach (var image in images)
                {
                    var imageModel = new ImageWithInfo();
                    imageModel.Name = image.Title;
                    imageModel.Source = ImageSource.FromFile(image.Path);
                    Images.Add(imageModel);
                }
            }
        }
    }
}
