using System;
using System.Windows.Forms;

namespace VirtualTaluva.Client.Windows.Forms.Lobby
{
    public partial class BlindUcAnte : UserControl
    {
        public BlindUcAnte()
        {
            InitializeComponent();
        }

        public void SetAnte( int ante )
        {
            lblAnte.Text = string.Format("${0}", ante);
        }
    }
}
