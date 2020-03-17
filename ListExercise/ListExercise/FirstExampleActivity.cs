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
    [Activity(Label = "FirstExampleActivity")]
    public class FirstExampleActivity : ListActivity
    {
        List<CarInfo> _items;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
             _items = new List<CarInfo>()
            {
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" },
                new CarInfo(){Manufacturer = "Audi",Model = "1",Year = "2002", KW = "1" }
            };            

            ListAdapter = new BasicAdapter(this, _items);

            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                var item = _items[args.Position];

                Toast.MakeText(Application, item.Manufacturer, ToastLength.Short).Show();
            };         
        }
        
    }
}