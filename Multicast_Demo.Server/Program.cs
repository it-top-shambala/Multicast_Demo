using System.Net;
using System.Net.Sockets;
using System.Text;
 
var messages = new[] { "Hello World!", "Hello METANIT.COM", "Hello work", "END" };
var broadcastAddress = IPAddress.Parse("235.5.5.11");
using var udpSender = new UdpClient();
Console.WriteLine("Начало отправки сообщений...");
foreach(var message in messages)
{
    Console.WriteLine($"Отправляется сообщение: {message}");
    var data = Encoding.UTF8.GetBytes(message);
    await udpSender.SendAsync(data, new IPEndPoint(broadcastAddress, 8001));
    await Task.Delay(1000);
}