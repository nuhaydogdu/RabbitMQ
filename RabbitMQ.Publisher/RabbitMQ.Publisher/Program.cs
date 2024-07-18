
using RabbitMQ.Client;
using System.Text;

//Bağlantı Oluşturma
ConnectionFactory factory = new();
factory.Uri = new("amqps://bcroqslz:aLcvABvoIwvfRYRxNkKz5-d3O2jvnDHH@shark.rmq.cloudamqp.com/bcroqslz");

//Bağlantıyı Aktifleştirme ve Kanal Açma
using IConnection connection =factory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Oluşturma 
channel.QueueDeclare(queue: "example-queue",exclusive: false);

//Queue'ye Mesaj Gönderme
//RabbitMQ kuyruğa atacağı mesajları byte türünde kabul etmektedir. Haliyle mesajları bizim byte dönüştürmemiz gerekecektir.
//default exchange, direkt excahange olacak. Böyle olunca da hangi kuyruğa mesaj göndereceksek o kuyruğun ismini routingKey'de bildirmiş olduk.
byte[] message = Encoding.UTF8.GetBytes("Merhaba");
channel.BasicPublish(exchange: "", routingKey: "example-queue", body: message);

Console.ReadLine(); 
























