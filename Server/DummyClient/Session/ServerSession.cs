﻿using Google.Protobuf;
using Google.Protobuf.Protocol;
using ServerCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace DummyClient
{
    public class ServerSession : PacketSession
    {
        public void Send(IMessage packet)
        {

            string packetName = packet.Descriptor.Name.Replace("_", string.Empty);
            PacketID packetID = (PacketID)Enum.Parse(typeof(PacketID), packetName);

            ushort size = (ushort)packet.CalculateSize();
            byte[] sendBuffer = new byte[size + 4];

            Array.Copy(BitConverter.GetBytes((ushort)(size + 4)), 0, sendBuffer, 0, sizeof(ushort));
            Array.Copy(BitConverter.GetBytes((ushort)(packetID)), 0, sendBuffer, sizeof(ushort), sizeof(ushort));
            Array.Copy(packet.ToByteArray(), 0, sendBuffer, 4, size);

            Send(new ArraySegment<byte>(sendBuffer));
        }

        public override void OnConnected(EndPoint endPoint)
        {

        }

        public override void OnDisconnected(EndPoint endPoint)
        {
        }

        public override void OnRecvedPacket(ArraySegment<byte> buffer)
        {
            PacketManager.Instance.OnRecvPacket(this, buffer);
        }
        public override void OnSended(int numOfByte)
        {
        }
    }
}
