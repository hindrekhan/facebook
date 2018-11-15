using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace facebook
{
    [Activity(Label = "CommentActivity")]
    public class CommentActivity : Activity
    {
        ListView listView;
        List<Comment> comments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_comment);

            comments = JsonConvert.DeserializeObject<List<Comment>>(Intent.GetStringExtra("comments"));

            var addComment = FindViewById<Button>(Resource.Id.addComment);
            addComment.Click += AddComment_Click;

            listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new CommentAdapter(this, comments);
        }

        private void AddComment_Click(object sender, EventArgs e)
        {
            var name = FindViewById<EditText>(Resource.Id.addCommentName);
            var content = FindViewById<EditText>(Resource.Id.addCommentContent);

            comments.Add(new Comment
            {
                Name = name.Text,
                Text = content.Text
            });

            listView.Adapter = new CommentAdapter(this, comments);
        }
    }
}