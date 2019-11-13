using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemLibraryData.RabbitMq
{
    public class Directmessages

    {

        private const string UName = "guest";

        private const string PWD = "guest";

        private const string HName = "localhost";

        public void SendMessage(Log req)

        {

            //Main entry point to the RabbitMQ .NET AMQP client

            var connectionFactory = new ConnectionFactory()

            {

                UserName = UName,

                Password = PWD,

                HostName = HName

            };

            var connection = connectionFactory.CreateConnection();

            var model = connection.CreateModel();

            var properties = model.CreateBasicProperties();

            properties.Persistent = false;

            var data = JsonConvert.SerializeObject(req);

            byte[] messagebuffer = Encoding.Default.GetBytes(data);

            model.BasicPublish("test", "testkey", properties, messagebuffer);

            Console.WriteLine("Message Sent");

        }

    }
}
