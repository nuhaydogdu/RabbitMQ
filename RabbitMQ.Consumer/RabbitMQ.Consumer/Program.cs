using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//Bağlantı Oluşturma
ConnectionFactory factory = new();
factory.Uri = new("amqps://bcroqslz:aLcvABvoIwvfRYRxNkKz5-d3O2jvnDHH@shark.rmq.cloudamqp.com/bcroqslz");

//Bağlantıyı Aktifleştirme ve Kanal Açma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Oluşturma 
//Consumer'da da kuyruk publisher'daki ile birebir aynı yapılandırmada tanımlanmalıdır!
channel.QueueDeclare(queue: "example-queue", exclusive: false);

//Queue'ye Mesaj Okuma
EventingBasicConsumer consumer = new(channel);
channel.BasicConsume(queue: "example-queue", false, consumer);
consumer.Received += (sender, e) =>
{
    //Kuyruğa gelen mesajın işlendiği yerdir!
    //e.Body: Kuyruktaki mesajın verisini bütünsel olarak getiriecektir.
    //e.Body.Span veya e.Body.ToArray(): Kuyruktaki mesajın byte verisini getirecektir.
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};

Console.ReadLine();
