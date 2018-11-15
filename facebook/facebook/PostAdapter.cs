﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace facebook
{
    class PostAdapter : BaseAdapter<Post>
    {
        List<Post> items;
        Activity context;
        List<TextView> likesTexts = new List<TextView>(new TextView[10]);

        public PostAdapter(Activity context, List<Post> items) : base()
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
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.PostRow, null);
            }

            var name = view.FindViewById<TextView>(Resource.Id.name);
            var likes = view.FindViewById<TextView>(Resource.Id.likes);
            var message = view.FindViewById<TextView>(Resource.Id.message);
            var comments = view.FindViewById<TextView>(Resource.Id.comments);
            var image = view.FindViewById<ImageView>(Resource.Id.image);
            var likeButton = view.FindViewById<ImageView>(Resource.Id.likeButton);

            name.Text = items[position].Name;
            likes.Text = items[position].Likes.ToString() + " Likes";
            message.Text = items[position].Message;
            comments.Text = items[position].Comments.Count.ToString() + " Comments";

            image.Visibility = ViewStates.Gone;
            if (items[position].Image != "")
            {
                image.SetImageResource(context.Resources.GetIdentifier(items[position].Image, "drawable", context.PackageName));
                image.Visibility = ViewStates.Visible;
            }

            likeButton.Click += LikeButton_Click;

            likeButton.Tag = position;
            likes.Tag = position;
            if (likesTexts[position] == null)
                likesTexts[position] = likes;
            comments.Click += delegate { CommentButton_Click(position); };
           
            return view;
        }

        // https://forums.xamarin.com/discussion/98966/custom-listview-adapter-button-click-give-value-to-edit-text
        public void LikeButton_Click(object sender, EventArgs e)
        {
            var LikeButton = (ImageView)sender;
            var pos = (int)LikeButton.Tag;
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

            var likes = likesTexts[pos];
            var a = (int)likes.Tag;
            likes.Text = curLikes.ToString() + " Likes";
        }

        private void CommentButton_Click(int pos)
        {
            Intent intent = new Intent(context, typeof(CommentActivity));
            intent.PutExtra("comments", JsonConvert.SerializeObject(items[pos].Comments));
            
            context.StartActivity(intent);
        }
    }
}