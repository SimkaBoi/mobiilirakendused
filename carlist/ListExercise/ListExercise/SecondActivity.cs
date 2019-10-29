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

namespace ListExercise
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {

        List<CarInfo> _items;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.second_layout);

            var queryString = $"https://swapi.co/api/people/?search=darth";
            var data = Core.DataService.GetStarWarsPeople(queryString);

            _items = new List<CarInfo>()
            {
                new CarInfo(){Manufacturer = "Audi", Model = "a", Year = "2000", KW = "1" },
                new CarInfo(){Manufacturer = "Skoda", Model = "b", Year = "2001", KW = "2" },
                new CarInfo(){Manufacturer = "Ford", Model = "c", Year = "2002", KW = "3" },
                new CarInfo(){Manufacturer = "Nissan" ,Model = "d", Year = "2003", KW = "4" },
                new CarInfo(){Manufacturer = "BMW", Model = "e", Year = "2004", KW = "5" },
                new CarInfo(){Manufacturer = "Lexus", Model = "f", Year = "2005", KW = "6" },
                new CarInfo(){Manufacturer = "Kia", Model = "g", Year = "2006", KW = "7" },
                new CarInfo(){Manufacturer = "Saab", Model = "h", Year = "2007", KW = "8" },
                new CarInfo(){Manufacturer = "Volvo", Model = "i", Year = "2008", KW = "9" },
                new CarInfo(){Manufacturer = "Volkswagen", Model = "j", Year = "2009", KW = "10" }
            };

            var listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new BasicAdapter(this, _items);

        }
    }
}