using VirtualTaluva.DataTypes;
using VirtualTaluva.Client.Windows.Forms.Game;

namespace VirtualTaluva.Client.Game
{
    public partial class RegisteredModeTableForm : TableForm
    {
        UserInfo User { get; set; }
        public RegisteredModeTableForm( UserInfo user )
        {
            User = user;
            InitializeComponent();
        }

        protected override int GetSitInMoneyAmount()
        {
            var parms = m_Game.Table.Params;
            //if (User.TotalMoney < parms.MinimumBuyInAmount)
            //    return -1;
            var bif = new BuyInForm(User, m_Game.Table.Params);
            bif.ShowDialog();
            if (bif.Ok)
                return bif.BuyIn;
            return -1;
        }
    }
}
