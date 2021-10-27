using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);

                string message = "Getting start with .NET Core RabbitMQ!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);

                Console.WriteLine($"Send the message: {message} ...");
            }

            Console.ReadLine();
        }
    }
}
