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
            var returnMessage = await ResolveMessage(activity);
            var reply = activity.CreateReply(returnMessage);
            await connector.Conversations.ReplyToActivityAsync(reply);
            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
    }
}