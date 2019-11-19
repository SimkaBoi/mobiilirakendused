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
using static Android.Widget.AdapterView;

namespace StarwarsApp
{
    [Activity(Label = "FilmActivity", Theme = "@style/SecondTheme")]
    public class FilmActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.film_list_layout);

            var queryString = "https://swapi.co/api/films/?search=";

            var films = await FilmDataService.GetStarWarsFilm(queryString);
            var filmsListView = FindViewById<ListView>(Resource.Id.filmList);
            filmsListView.Adapter = new StarWarsFilmAdapter(this, films.Results);

            filmsListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                var a = Convert.ToString(filmsListView.GetItemAtPosition(e.Position));
                var bText = Convert.ToString(e.Position);
            };

            /* old
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.search_layout);

            var searchField = FindViewById<EditText>(Resource.Id.searchEditText);
            var listView = FindViewById<ListView>(Resource.Id.searchListView);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            await InitSearch();

            async Task InitSearch()
            {
                var queryString = "https://swapi.co/api/films/?search=";
                var data = await FilmDataService.GetStarWarsFilm(queryString);
                listView.Adapter = new StarWarsFilmAdapter(this, data.Results);
            }

            searchButton.Click += async delegate
            {
                var searchText = searchField.Text;
                var queryString = "https://swapi.co/api/films/?search=" + searchText;
                var data = await FilmDataService.GetStarWarsFilm(queryString);
                listView.Adapter = new StarWarsFilmAdapter(this, data.Results);
            };
            */
        }
    }
}