using VirtualTaluva.Client.Windows.Forms.Game;
using VirtualTaluva.Protocol.DataTypes.Options;

namespace VirtualTaluva.Client.Game
{
    public partial class QuickModeTableForm : TableForm
    {
        public QuickModeTableForm()
        {
            InitializeComponent();
        }

        protected override int GetSitInMoneyAmount()
        {
            return ((LobbyOptionsQuickMode)m_Game.Table.Params.Lobby).StartingAmount;
        }
    }
}
