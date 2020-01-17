﻿using Microsoft.AspNetCore.Mvc;
using QueueMessageSender.Logic;
using QueueMessageSender.Models;

namespace QueueMessageSender.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IQueueMessageSender _sender;

        public MessagesController(IQueueMessageSender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// A method that accepts JSON with message information and sends the message in exchange.
        /// </summary>
        [HttpPost]
        public IActionResult Post(ReceivedDataModel model)
        {
            var departureData = new DepartureDataModel
            {
                NameExchange = model.Exchange,
                RoutingKey = model.Key,
                Message = model.Message
            };
            _sender.SendMessage(departureData);

            return Ok();
        }
    }
}