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
using StarwarsApp.Core.Models;

namespace StarwarsApp
{
    public class StarWarsFilmAdapter : BaseAdapter<FilmDetails>
    {
        List<FilmDetails> _items;
        Activity _context;

        public StarWarsFilmAdapter(Activity context, List<FilmDetails> items) : base()
        {
            this._context = context;
            this._items = items;
        }

        public override FilmDetails this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];

            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.film_list_layout, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Title;
            //view.FindViewById<TextView>(Resource.Id.textView2).Text = item.release_date.Year.ToString();
            //view.FindViewById<TextView>(Resource.Id.textView3).Text = item.opening_crawl;

            return view;
        }
    }
}