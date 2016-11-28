using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using logitblog_bot.Models;

namespace logitblog_bot.Services
{
    public class PostsService
    {
        public async Task<Rootobject> GetPosts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.logitblog.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var path = "api/get_posts?count=1";
            Rootobject post = new Rootobject();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                post = await response.Content.ReadAsAsync<Rootobject>();
            }

            return post;
        }

        public async Task<Rootobject> SearchPost(string search)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.logitblog.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var path = $"api/get_search_results/?search={search}&count=30";
            var posts = new Rootobject();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                posts = await response.Content.ReadAsAsync<Rootobject>();
            }

            return posts;
        }
    }
}