using System.Collections.Generic;
using System.Net;
using IConstituent.MessageService.DataService;
using IConstituent.MessageService.DataStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IConstituentMessageService.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {

        private readonly IMessageDataService messageDataService;

        public MessageController(IMessageDataService messageDataService)
        {
            this.messageDataService = messageDataService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Message>), (int)HttpStatusCode.OK)]
        /// <summary>
        /// Gets all the messages registered in the server.
        /// </summary>
        public IEnumerable<Message> GetAllMessages()
        {
            return this.messageDataService.GetAllMessages();
        }

        [HttpGet("{messageId}")]
        [ProducesResponseType(typeof(Message), (int)HttpStatusCode.OK)]
        /// <summary>
        /// Gets the detailed information of the message.
        /// </summary>
        /// <param name="messageId">Id of the message to be retrieved</param>
        /// <response code="404">The message id doesn't exist in our server.</response>
        public IActionResult GetMessage(long messageId)
        {
            var result = this.messageDataService.GetMessage(messageId);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Message), (int)HttpStatusCode.OK)]
        /// <summary>
        /// Adds a new message to the server.
        /// </summary>
        /// <param name="message">Message to be inserted to the server.</param>
        /// <response code="200">The message was inserted correctly.</response>
        /// <response code="400">There are issues inserting the message, most likely some required parameters are not present in the request.</response>
        public IActionResult AddMessage([FromBody] Message message)
        {
            var result = this.messageDataService.SendMessage(message);

            if (result == null)
            {
                return this.BadRequest();
            }

            return this.Ok(result);
        }
    }
}
