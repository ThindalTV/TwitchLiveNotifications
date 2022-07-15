﻿using Azure.Storage.Queues;
using Microsoft.Extensions.Logging;
using System;

namespace TwitchLiveNotifications.Helpers
{
    internal class QueueHelpers
    {
        public static void SendMessage(ILogger logger, QueueServiceClient queueClientService, string queueNameVariable, string message)
        {
            string queueName = Environment.GetEnvironmentVariable(queueNameVariable);
            if (string.IsNullOrEmpty(queueName))
            {
                logger.LogInformation("Environment variable '{queueNameVariable}' is empty, no message posted", queueNameVariable);
                return;
            }

            var queueClient = queueClientService.GetQueueClient(queueName);
            queueClient.CreateIfNotExists();
            queueClient.SendMessage(message);
        }
    }
}
