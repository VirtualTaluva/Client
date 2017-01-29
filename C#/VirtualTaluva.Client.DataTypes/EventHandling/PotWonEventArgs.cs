using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Protocol.DataTypes.EventHandling;

namespace VirtualTaluva.Client.DataTypes.EventHandling
{
    public class PotWonEventArgs : PlayerInfoEventArgs
    {
        private readonly int m_Id;
        private readonly int m_AmountWon;
        private readonly PokerHandEnum m_Hand;
        private readonly string[] m_Cards;

        public int Id { get { return m_Id; } }
        public int AmountWon { get { return m_AmountWon; } }
        public PokerHandEnum Hand { get { return m_Hand; } }
        public string[] Cards { get { return m_Cards; } }

        public PotWonEventArgs(PlayerInfo p, int id, int amntWon, PokerHandEnum hand, string[] cards)
            : base(p)
        {
            m_Id = id;
            m_AmountWon = amntWon;
            m_Hand = hand;
            m_Cards = cards;
        }
    }
}
