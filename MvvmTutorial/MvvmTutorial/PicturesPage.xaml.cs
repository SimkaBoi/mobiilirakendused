﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmTutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicturesPage : ContentPage
    {
        public PicturesPage()
        {
            InitializeComponent();
        }
    }
}