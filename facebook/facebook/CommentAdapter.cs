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
    class CommentAdapter : BaseAdapter<Comment>
    {
        List<Comment> items;
        Activity context;

        public CommentAdapter(Activity context, List<Comment> items) : base()
        {
            this.context = context;
            this.items = items;
        }


        public override Comment this[int position]
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
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.PostRow, null);
            }

            return view;
        }
    }
}