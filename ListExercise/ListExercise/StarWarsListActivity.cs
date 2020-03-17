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
using ListExercise.Core;

namespace ListExercise
{
    [Activity(Label = "StarWarsListActivity")]
    public class StarWarsListActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.starwars_people_layout);

            var searchField = FindViewById<EditText>(Resource.Id.editText1);
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            var searchButton = FindViewById<Button>(Resource.Id.button1);
            searchButton.Click += async delegate
            {
                var searchText = searchField.Text;
                var queryString = "https://swapi.co/api/people/?search=" + searchText;
                var data = await DataService.GetStarWarsPeople(queryString);
                listView.Adapter = new StarWarsPeopleAdapter(this, data.Results);
            };

        }
    }
}