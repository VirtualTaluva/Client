using VirtualTaluva.Client.DataTypes.EventHandling;
using VirtualTaluva.Protocol.DataTypes;

namespace VirtualTaluva.Client.DataTypes
{
    public interface IPokerGame
    {
        PokerGameObserver Observer { get; }

        TableInfo Table { get; }

        bool PlayMoney(PlayerInfo p, int amnt);
        int AfterPlayerSat(PlayerInfo p, int noSeat = -1, int moneyAmount = 1500);
        bool SitOut(PlayerInfo p);

        void Discard(string[] cards);

        bool IsPlaying { get; }
    }
}
