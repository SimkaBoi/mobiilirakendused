using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstForms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string _name = "notes.txt";
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "");

        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName + "notes.txt"))
            {
                editor.Text = File.ReadAllText(_fileName + "notes.txt");
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if(fileName.Text == "")
            {
                File.WriteAllText(_fileName + "notes.txt", editor.Text);
            }
            else
            {
                File.WriteAllText(_fileName + fileName.Text + ".txt", editor.Text);
            }
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }

        void OnOpenButtonClicked(object sender, EventArgs e)
        {
            _name = fileName.Text;
            string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _name + ".txt");
            if(File.Exists(file))
            {
                File.ReadAllText(file);
            }
        }
    }
}
