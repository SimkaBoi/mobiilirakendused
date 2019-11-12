using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using StarwarsApp.Core;

namespace StarwarsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/SecondTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toPeopleActivityButton = FindViewById<Button>(Resource.Id.peopleButton);
            var toPlanetActivityButton = FindViewById<Button>(Resource.Id.planetsButton);
            var toStarshipActivityButton = FindViewById<Button>(Resource.Id.starshipsButton);
            var toFilmsActivityButton = FindViewById<Button>(Resource.Id.filmsButton);

            toPeopleActivityButton.Click += toPeopleActivityButton_Click;
            toPlanetActivityButton.Click += toPlanetActivityButton_Click;
            toStarshipActivityButton.Click += toStarshipActivityButton_Click;
            toFilmsActivityButton.Click += toFilmActivityButton_Click;
        }

        private void toFilmActivityButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FilmListActivity));
            StartActivity(intent);
        }

        private void toPeopleActivityButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PeopleListActivity));
            StartActivity(intent);
        }

        private void toPlanetActivityButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PlanetListActivity));
            StartActivity(intent);
        }

        private void toStarshipActivityButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(StarshipListActivity));
            StartActivity(intent);
        }
    }
}