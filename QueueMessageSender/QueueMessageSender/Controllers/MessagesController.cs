﻿using Microsoft.AspNetCore.Mvc;
using QueueMessageSender.Controllers.Entities;
using QueueMessageSender.Logic;
using QueueMessageSender.Logic.Entities;

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
        public IActionResult Post(VerificationDataModel model)
        {
            var departureData = new DepartureDatаRMQModel
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