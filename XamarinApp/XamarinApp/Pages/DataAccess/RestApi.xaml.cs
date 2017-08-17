using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp.Pages.DataAccess
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestApi : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        HttpClient _client = new HttpClient(new NativeMessageHandler());
        private ObservableCollection<Post> _posts;

        public RestApi ()
		{
			InitializeComponent ();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            listView.ItemsSource = _posts;
            base.OnAppearing();
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            var post = new Post()
            {
                Title = "Post " + DateTime.Now.Ticks
            };
            var newPost = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url, new StringContent(newPost));
            _posts.Insert(0, post);
        }

        private async void OnUpdate(object sender, EventArgs e)
        {
            var post = _posts[0];
            post.Title += " Updated";

            var updatedPost = JsonConvert.SerializeObject(post);
            await _client.PutAsync(Url + "/" + post.Id, new StringContent(updatedPost));
        }

        private async void OnDelete(object sender, EventArgs e)
        {
            var post = _posts[0];
            await _client.DeleteAsync(Url + "/" + post.Id);
            _posts.Remove(post);
        }
    }
}