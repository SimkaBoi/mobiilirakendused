﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StarwarsApp.Core;

namespace StarwarsApp
{
    [Activity(Label = "FilmListActivity", Theme = "@style/SecondTheme")]
    public class FilmListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.search_layout);

            var searchField = FindViewById<EditText>(Resource.Id.searchEditText);
            var listView = FindViewById<ListView>(Resource.Id.searchListView);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            searchButton.Click += async delegate
            {
                var searchText = searchField.Text;
                var queryString = "https://swapi.co/api/films/?search=" + searchText;
                var data = await FilmDataService.GetStarWarsFilm(queryString);
                listView.Adapter = new StarWarsFilmAdapter(this, data.Results);
            };
        }
    }
}