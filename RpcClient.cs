using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class RpcClient
{
    private const int ServerPort = 12345;
    private const string ServerIpAddress = "127.0.0.1";

    public static void Main()
    {
        try
        {
            // Connect to the RPC server
            TcpClient client = new TcpClient(ServerIpAddress, ServerPort);
            Console.WriteLine("Connected to the RPC server.");

            // Get the network stream for sending and receiving data
            NetworkStream stream = client.GetStream();

            // Prepare the data to be sent
            string data = "Hello, RPC server!";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            // Send the data to the server
            stream.Write(buffer, 0, buffer.Length);
            Console.WriteLine("Data sent to the RPC server.");

            // Clean up
            stream.Close();
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
