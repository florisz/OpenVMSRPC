using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class RpcServer
{
    public static void Main()
    {
        // Register the channel to communicate over TCP
        TcpChannel channel = new TcpChannel(1234);
        ChannelServices.RegisterChannel(channel, false);

        // Register the server object
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(MyRemoteObject), "MyRemoteObject", WellKnownObjectMode.Singleton);

        Console.WriteLine("RPC server started. Listening for requests...");

        // Keep the server running until the user presses a key
        Console.ReadKey();
    }
}

public class MyRemoteObject : MarshalByRefObject
{
    // Implement your remote methods here
}


