﻿using System;
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
using Newtonsoft.Json;
using StarwarsApp.Activities;
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
            SetContentView(Resource.Layout.film_layout);
            var queryString = "https://swapi.co/api/films/?search=";

            var films = await FilmDataService.GetStarWarsFilm(queryString);
            var filmsListView = FindViewById<ListView>(Resource.Id.searchListView);
            filmsListView.Adapter = new StarWarsFilmAdapter(this, films.Results);

            filmsListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                var filmDetails = films.Results[e.Position];

                var intent = new Intent(this, typeof(FilmDetailsActivity));
                intent.PutExtra("filmDetails", JsonConvert.SerializeObject(filmDetails));
                StartActivity(intent);
            };
        }
    }
}