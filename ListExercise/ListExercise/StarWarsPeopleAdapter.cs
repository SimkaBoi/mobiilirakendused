using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;
using ListExercise.Core;

namespace ListExercise
{
    public class StarWarsPeopleAdapter : BaseAdapter<PeopleDetails>
    {
        List<PeopleDetails> _items;
        Activity _context;

        public StarWarsPeopleAdapter(Activity context, List<PeopleDetails> items) : base()
        {
            this._context = context;
            this._items = items;
        }

        public override PeopleDetails this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.car_row, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Height.ToString();
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.Mass.ToString();
            view.FindViewById<TextView>(Resource.Id.textView4).Text = item.Gender.ToString();

            return view;
        }
    }
}