using MessagingDemo.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingDemo
{
    public class StandardQueue
    {
        private IConnection _connection;
        private IModel _model;
        private const string QUEUE_NAME = "STANDARD_QUEUE";
        public StandardQueue()
        {
            CreateConnection();
        }

        public static void Initialize()
        {
            var standardQueue = new StandardQueue();

            for(int i = 0; i< 10; i++)
            {
                var payment = new Payment
                {
                    AmountToPay = i * 10000,
                    CardNumber = "XXXX-XXXX-XXXX-XXXX",
                    Name = "Hariharan"
                };
                standardQueue.PublishPayment(payment);
            }

            Console.WriteLine("Press enter to trigger consumption of messages");
            Console.ReadLine();

            standardQueue.InitiateConsumption();
        }

        private void InitiateConsumption()
        {
            var consumer = new EventingBasicConsumer(_model);
            consumer.Received += Consumer_Received;
            _model.BasicConsume(QUEUE_NAME, true, consumer);
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var payment = e.Body.Deserialize<Payment>();
            Console.WriteLine($"Payment for {payment.AmountToPay} has been recovered from {payment.CardNumber} belongs to {payment.Name}");
        }

        private void CreateConnection()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare(QUEUE_NAME, true, false, false, null);
        }

        public void PublishPayment(Payment payment)
        {
            _model.BasicPublish("", QUEUE_NAME, null, payment.Serialize());
        }
    }
}
