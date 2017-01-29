﻿using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.EventHandling;

namespace VirtualTaluva.Client.DataTypes.EventHandling
{
    public class MinMaxEventArgs : PlayerInfoEventArgs
    {
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        public MinMaxEventArgs(PlayerInfo player, int min, int max) : base(player)
        {
            Minimum = min;
            Maximum = max;
        }
    }
}
