using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;

namespace XamarinApp.Services
{
    public class MovieService
    {
        private HttpClient _client = new HttpClient(new NativeMessageHandler());
        private const string Url = "http://netflixroulette.net/api/api.php";

        public async Task<IEnumerable<Movie>> FindMoviesByActor(string actor)
        {
            var response = await _client.GetAsync($"{Url}?actor={actor}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<Movie>();
            }

            var movies = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Movie>>(movies);
        }

        public async Task<Movie> GetMovie(string title)
        {
            var movie = await _client.GetStringAsync($"{Url}?title={title}");
            return JsonConvert.DeserializeObject<Movie>(movie);
        }
    }
}
