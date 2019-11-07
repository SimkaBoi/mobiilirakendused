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
using StarwarsApp.Core.Models;

namespace StarwarsApp
{
    public class StarWarsPlanetAdapter : BaseAdapter<PlanetDetails>
    {
        List<PlanetDetails> _items;
        Activity _context;

        public StarWarsPlanetAdapter(Activity context, List<PlanetDetails> items) : base()
        {
            this._context = context;
            this._items = items;
        }

        public override PlanetDetails this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.search_row_layout, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Terrain.ToString();
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.Population.ToString();
            view.FindViewById<TextView>(Resource.Id.textView4).Text = item.Climate.ToString();

            return view;
        }
    }
}