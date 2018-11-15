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
        List<Post> posts;
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            posts = new List<Post>
            {
                new Post
                {
                    Comments = new List<Comment>
                    {
                        new Comment { Name = "Jimmy Neutron", Text = "Suht lahe"}
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
                },
                new Post
                {
                    Comments = new List<Comment>
                    {
                        new Comment { Name = "Jimmy Neutron", Text = "Suht lahe"}
                    },
                    Likes = 74123436,
                    Message = "Hello World!",
                    Name = "Stefan",
                    Image = "dog"
                },
                new Post
                {
                    Comments = new List<Comment>
                    {
                        new Comment { Name = "Jimmy Neutron", Text = "Suht lahe"}
                    },
                    Likes = 63,
                    Message = "Hello World!",
                    Name = "Stefan",
                },
                new Post
                {
                    Comments = new List<Comment>
                    {
                        new Comment { Name = "Jimmy Neutron", Text = "Suht lahe"}
                    },
                    Likes = 7432,
                    Message = "Hello World!",
                    Name = "Stefan",
                    Image = "child"
                },
            };

            var addPost = FindViewById<Button>(Resource.Id.addPost);
            addPost.Click += AddPost_Click;

            listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new PostAdapter(this, posts);
        }

        private void AddPost_Click(object sender, System.EventArgs e)
        {
            var name = FindViewById<EditText>(Resource.Id.addPostName);
            var content = FindViewById<EditText>(Resource.Id.addPostContent);

            posts.Add(new Post
            {
                Name = name.Text,
                Message = content.Text
            });

            listView.Adapter = new PostAdapter(this, posts);
        }
    }
}