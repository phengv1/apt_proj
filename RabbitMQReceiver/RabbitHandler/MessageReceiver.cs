using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using SystemLibraryData;

namespace RabbitConsole
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        int i = 1;

        private readonly IModel _channel;
        LogData logDataHandler = new LogData();
        Log log = new Log();

        public MessageReceiver(IModel channel)

        {

            _channel = channel;

        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, byte[] body)
        {

            Console.WriteLine($"Consuming Message");

            Console.WriteLine(string.Concat("Message received from the exchange ", exchange));

            Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));

            Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));

            Console.WriteLine(string.Concat("Routing tag: ", routingKey));

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(string.Concat("Message: ", Encoding.UTF8.GetString(body)));

            Console.ResetColor();

            _channel.BasicAck(deliveryTag, false);

            var data = Encoding.UTF8.GetString(body);

            var logInfo = JsonConvert.DeserializeObject<Log>(data);

            var chk = logDataHandler.AddLogInfo(logInfo.Date, logInfo.Action, logInfo.Message, logInfo.Exception);

            if (chk == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Insert Successfully!");
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Insert failed!");
                Console.ResetColor();
            } 

            Console.WriteLine("-------------------------------------------------------------------------");

            
        }

    }
}
