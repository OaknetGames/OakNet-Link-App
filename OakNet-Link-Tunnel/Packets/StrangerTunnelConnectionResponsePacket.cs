﻿using OakNetLink.Api.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OakNetLink.Tunnel.Packets
{
    internal class StrangerTunnelConnectionResponsePacket : PacketBase
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public string Response { get; set; }
        public byte[] PeerID { get; set; }
    }
}
