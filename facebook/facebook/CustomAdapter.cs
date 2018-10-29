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

namespace facebook
{
    class CustomAdapter : BaseAdapter<Post>
    {
        List<Post> items;
        Activity context;

        public CustomAdapter(Activity context, List<Post> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override Post this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);


            view.FindViewById<TextView>(Resource.Id.name).Text = items[position].Name;
            view.FindViewById<TextView>(Resource.Id.likes).Text = items[position].Likes.ToString() + " Likes";
            view.FindViewById<TextView>(Resource.Id.message).Text = items[position].Message;
            view.FindViewById<TextView>(Resource.Id.comments).Text = items[position].Comments.ToString() + " Comments";

            return view;
        }
    }
}