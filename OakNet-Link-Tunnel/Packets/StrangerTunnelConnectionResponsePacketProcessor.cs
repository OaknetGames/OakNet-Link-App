﻿using OakNetLink.Api.Communication;
using OakNetLink.Api.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakNetLink.Tunnel.Packets
{
    internal class StrangerTunnelConnectionResponsePacketProcessor : PacketProcessor
    {
        public override PacketBase ProcessPacket(PacketBase packet, OakNetEndPoint endpoint)
        {
            var responsePacket = packet as StrangerTunnelConnectionResponsePacket;
            if (responsePacket == null) return null;

            var receipient = OakNetEndPointManager.GetEndPoint(new Guid(responsePacket.PeerID));
            if (receipient == null) return null;

            var newResponse = new TunnelConnectionResponsePacket();
            if (responsePacket.Response == "accepted")
            {
                newResponse.Address = endpoint.IpAddress.ToString();
                newResponse.Port = endpoint.Port;
                newResponse.PeerID = endpoint.PeerID.ToByteArray();
                newResponse.Message = "accepted";
            }
            newResponse.IP = TunnelPlugin.Manager.getAddress(endpoint);
            newResponse.Message = responsePacket.Response;
            receipient.sendPacket(newResponse, true);

            return null;
        }
    }
}
