﻿using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using ServerCore;

namespace DummyClient
{
    internal class ClientP
    {
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();

            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress ipAddr = ipEntry.AddressList[1];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);

            while (true)
            {

                Connector connector= new Connector();
                connector.Connect(endPoint, () => { return new ServerSession(); });

                Thread.Sleep(1000);
            }
        }
    }
}
