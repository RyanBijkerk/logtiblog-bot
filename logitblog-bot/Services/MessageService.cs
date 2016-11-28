using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logitblog_bot.Models;
using Microsoft.Bot.Connector;

namespace logitblog_bot.Services
{
    public class MessageService
    {

        private readonly LuisService _luisService;
        private readonly PostsService _postsService;

        public MessageService()
        {
            _luisService = new LuisService();
            _postsService = new PostsService();
        }


        public async Task<string> ResolveMessage(Activity activity)
        {
            var messageString = "";
            if (activity.Type == ActivityTypes.Message)
            {
                messageString = "Sorry, I am not getting you...";

                var entity = await _luisService.GetEntity(activity.Text);
                if (entity.intents.Any())
                {
                    switch (entity.intents[0].intent)
                    {
                        case "blog.intro":
                            messageString = await CreateIntroMessage();

                            break;

                        case "blog.owner":
                            messageString = await CreateOwnerMessage();

                            break;

                        case "blog.authors":
                            messageString = await CreateAuthorsMessage();

                            break;

                        case "blog.post":
                            var packageListCount = await _postsService.GetPosts();
                            messageString = await CreateCountPostMessage(packageListCount);

                            break;

                        case "blog.post.search":

                            if (!entity.entities.Any())
                            {
                                break;
                            }

                            var postSearch = await _postsService.SeachPost(entity.entities[0].entity);
                            messageString = await CreateSearchPostMessage(postSearch);

                            break;

                        default:
                            messageString = "Sorry, I am not getting you...";

                            break;
                    }
                }
            }
            else
            {
                await HandleSystemMessage(activity);
            }

            return messageString;
        }


        public async Task<string> CreateIntroMessage()
        {
            return await Task.Run(() =>
            {
                var messageString = "Hi, I'm the Logit Bot. \n\n";
                messageString += "Ask me anything about Logit Blog!";

                return messageString;
            });

        }

        public async Task<string> CreateOwnerMessage()
        {
            return await Task.Run(() =>
            {
                var messageString = "Logit Blog is created by Ryan Bijkerk November 2010. \n\n";
                messageString += "The main goal of Logit Blog is to share experience with the community.";

                return messageString;
            });

        }

        public async Task<string> CreateAuthorsMessage()
        {
            return await Task.Run(() =>
            {
                var messageString = "The main author is Ryan Bijkerk but sometimes guest are publishing at Logit Blog. \n\n";
                return messageString;
            });

        }

        public async Task<string> CreateCountPostMessage(Rootobject postList)
        {
            return await Task.Run(() =>
            {
                string messageString = null;
                if (postList.posts != null)
                {
                    messageString = $"Here are the details of the latest publication:\n\n";

                    foreach (var post in postList.posts)
                    {
                        messageString += $"Publised on {post.date} \n\n";
                        messageString += $"{post.title} \n\n";
                        messageString += $"{post.url} \n\n";
                    }
                }
                return messageString;
            });
        }
        public async Task<string> CreateSearchPostMessage(Rootobject postList)
        {
            return await Task.Run(() =>
            {
                string messageString = "Nope, I could not find any related posts...";
                if (postList.posts != null)
                {
                    messageString = $"Yes! {postList.posts.Count()}\n\n";

                    foreach (var post in postList.posts)
                    {
                        messageString += $"{post.title} \n\n";
                        messageString += $"{post.url} \n\n";
                    }
                }
                return messageString;
            });
        }


        public async Task HandleSystemMessage(Activity message)
        {
            await Task.Run(() =>
            {
                if (message.Type == ActivityTypes.DeleteUserData)
                {
                    // Implement user deletion here
                    // If we handle user deletion, return a real message
                }
                else if (message.Type == ActivityTypes.ConversationUpdate)
                {
                    // Handle conversation state changes, like members being added and removed
                    // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                    // Not available in all channels
                }
                else if (message.Type == ActivityTypes.ContactRelationUpdate)
                {
                    // Handle add/remove from contact lists
                    // Activity.From + Activity.Action represent what happened
                }
                else if (message.Type == ActivityTypes.Typing)
                {
                    // Handle knowing tha the user is typing
                }
                else if (message.Type == ActivityTypes.Ping)
                {
                }

                return null;
            });
        }

    }
}