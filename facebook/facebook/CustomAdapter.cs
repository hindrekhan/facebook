using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
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

            var name = view.FindViewById<TextView>(Resource.Id.name);
            var likes = view.FindViewById<TextView>(Resource.Id.likes);
            var message = view.FindViewById<TextView>(Resource.Id.message);
            var comments = view.FindViewById<TextView>(Resource.Id.comments);
            var image = view.FindViewById<ImageView>(Resource.Id.image);
            var likeButton = view.FindViewById<ImageView>(Resource.Id.likeButton);

            name.Text = items[position].Name;
            likes.Text = items[position].Likes.ToString() + " Likes";
            message.Text = items[position].Message;
            comments.Text = items[position].Comments.ToString() + " Comments";

            image.Visibility = ViewStates.Gone;
            if (items[position].Image != "")
            {
                image.SetImageResource(context.Resources.GetIdentifier(items[position].Image, "drawable", context.PackageName));
                image.Visibility = ViewStates.Visible;
            }

            likeButton.Click += (sender, e) => LikeButton_Click(position, likes);


            return view;
        }

        // https://forums.xamarin.com/discussion/98966/custom-listview-adapter-button-click-give-value-to-edit-text
        private void LikeButton_Click(int pos, TextView likes)
        {
            int curLikes = items[pos].Likes;

            if (items[pos].Liked)
            {
                curLikes--;
            }

            else
            {
                curLikes++;
            }

            items[pos].Liked = !items[pos].Liked;
            items[pos].Likes = curLikes;

            likes.Text = curLikes.ToString() + " Likes";

        }
    }
}