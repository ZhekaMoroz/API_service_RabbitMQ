﻿using QueueMessageSender.Models;

namespace QueueMessageSender.Logic
{
    /// <summary>
    /// Abstraction to publish messages to the queue.
    /// </summary>
    interface IQueueMessageSender
    {
        void SendMessage(DepartureData data);
    }
}
