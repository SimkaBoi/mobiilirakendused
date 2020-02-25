using FFImageLoading.Forms;
using MvvmTutorial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            Pictures = new List<Picture>
            {
                new Picture { Title = "title1", Desc = "desc1", Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Date = DateTime.Now },
                new Picture { Title = "title2", Desc = "desc2", Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Date = DateTime.Now },
                new Picture { Title = "title3", Desc = "desc3", Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Date = DateTime.Now },
                new Picture { Title = "title4", Desc = "desc4", Image = "http://loremflickr.com/600/600/nature?filename=simple.jpg", Date = DateTime.Now },
                new Picture { Title = "obamium", Desc = "oboomer", Image = "obamium.jpg", Date = DateTime.Now },
            };
        }

        private List<Picture> _pictures;
        public List<Picture> Pictures
        {
            get { return _pictures; }
            set
            {
                if (_pictures != value)
                {
                    _pictures = value;
                    OnPropertyChanged(nameof(Pictures));
                }
            }
        }
    }
}
