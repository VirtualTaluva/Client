using System;
using VirtualTaluva.Protocol.DataTypes.Options;

namespace VirtualTaluva.Client.DataTypes.EventHandling
{
    public class GameMessageOptionEventArgs : EventArgs
    {
        public GameMessageOption Info { get; }

        public GameMessageOptionEventArgs(GameMessageOption o)
        {
            Info = o;
        }
    }
}
