using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;

namespace facebook
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Comments = new List<Comment>
                    {
                        new Comment { Name = "Jimmy Newtron", Text = "Suht lahe"}
                    },
                    Likes = 5,
                    Message = "Hello World!",
                    Name = "Stefan",
                    Image = "cat"
                },

                new Post
                {
                    Likes = 235235,
                    Message = "Hello World!",
                    Name = "Hindrek"
                }
            };

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new PostAdapter(this, posts);
        }
    }
}