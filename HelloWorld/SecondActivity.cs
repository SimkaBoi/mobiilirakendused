using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HelloWorld
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        TextView _vastus;
        Button _liida;
        Button _lahuta;
        Button _korruta;
        Button _jaga;
        EditText _textField1;
        EditText _textField2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_layout);
            // Create your application here
            _textField1 = FindViewById<EditText>(Resource.Id.arv1);
            _textField2 = FindViewById<EditText>(Resource.Id.arv2);
            
            int arv1 = Convert.ToInt32(_textField1.Text);
            int arv2 = Convert.ToInt32(_textField2.Text);
            var x = "";
            _liida.Click += delegate
            {
                x = "+";
                _vastus.Text = Convert.ToString(Arvuta(arv1, arv2, x));
            };
            _lahuta.Click += delegate
            {
                x = "-";
                _vastus.Text = Convert.ToString(Arvuta(arv1, arv2, x));
            };
            _korruta.Click += delegate
            {
                x = "*";
                _vastus.Text = Convert.ToString(Arvuta(arv1, arv2, x));
            };
            _jaga.Click += delegate
            {
                x = "/";
                _vastus.Text = Convert.ToString(Arvuta(arv1, arv2, x));
            };
        }

        public int Arvuta(int arv1, int arv2, string x)
        {
            if(x == "+")
            {
                return arv1 + arv2;
            }
            else if(x == "-")
            {
                return arv1 - arv2;
            }
            else if(x == "*")
            {
                return arv1 * arv2;
            }
            else if(x == "/")
            {
                return arv1 / arv2;
            }
            else
            {
                return 0;
            }
        }
    }
}