using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using logitblog_bot.Services;
using Microsoft.Bot.Connector;

namespace logitblog_bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly MessageService _messageService;

        public MessagesController()
        {
            _messageService = new MessageService();
        }

        public async Task<string> ResolveMessage(Activity activity)
        {
            return await _messageService.ResolveMessage(activity);
        }

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        [Route("api/messages")]
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));


            if (activity.Type != ActivityTypes.Message)
            {
                await HandleSystemMessage(activity);
                
            }
            else
            {
                var returnMessage = await ResolveMessage(activity);
                var reply = activity.CreateReply(returnMessage);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            
            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }


        private async Task HandleSystemMessage(Activity message)
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
                    var messageString = "ping";
                    message.Type = "ping";
                    return message.CreateReply(messageString);
                }

                return null;
            });
        }

    }
}