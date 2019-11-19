using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StarwarsApp.Core;

namespace StarwarsApp
{
    [Activity(Label = "PlanetActivity", Theme = "@style/SecondTheme")]
    public class PlanetActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.search_layout);

            var searchField = FindViewById<EditText>(Resource.Id.searchEditText);
            var listView = FindViewById<ListView>(Resource.Id.searchListView);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            await InitSearch();

            async Task InitSearch()
            {
                var queryString = "https://swapi.co/api/planets/?search=";
                var data = await PlanetDataService.GetStarWarsPlanets(queryString);
                listView.Adapter = new StarWarsPlanetAdapter(this, data.Results);
            }

            searchButton.Click += async delegate
            {
                var searchText = searchField.Text;
                var queryString = "https://swapi.co/api/planets/?search=" + searchText;
                var data = await PlanetDataService.GetStarWarsPlanets(queryString);
                listView.Adapter = new StarWarsPlanetAdapter(this, data.Results);
            };
        }
    }
}