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
    [Activity(Label = "CommentActivity")]
    public class CommentActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            //ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            //listView.Adapter = new PostAdapter(this, posts);
        }
    }
}