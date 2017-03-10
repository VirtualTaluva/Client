using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Protocol.Enums;

namespace VirtualTaluva.Client.DataTypes
{
    public class Compatibility
    {
        public bool Success { get; set; }
        public TaluvaMessageId MessageId { get; set; }
        public string Message { get; set; }
        public string ImplementedProtocolVersion { get; set; }
        public LobbyTypeEnum[] SupportedLobbyTypes { get; set; }
        public GameInfo[] AvailableGames { get; set; }
        public string ServerIdentification { get; set; }
    }
}
