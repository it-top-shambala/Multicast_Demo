using System.Net.Sockets;
using System.Net;
using System.Text;
 
using var udpClient = new UdpClient(8001);
var broadcastAddress = IPAddress.Parse("235.5.5.11");
udpClient.JoinMulticastGroup(broadcastAddress);
Console.WriteLine("Начало прослушивания сообщений");
while (true)
{
    var result = await udpClient.ReceiveAsync();
    var message = Encoding.UTF8.GetString(result.Buffer);
    if (message == "END") break;
    Console.WriteLine(message);
}

udpClient.DropMulticastGroup(broadcastAddress);
Console.WriteLine("Udp-клиент завершил свою работу");