﻿using VirtualTaluva.Client.Splash;
using Com.Ericmas001.Windows.Forms;
using System;
using System.Windows.Forms;

namespace VirtualTaluva.Client.Menu
{
    public partial class RegisteredModeConnectParmsForm : Form
    {
        private readonly string m_ServerAdress;
        private readonly int m_ServerPort;

        public RegisteredModeConnectParmsForm(string serverAddress, int serverPort)
        {
            InitializeComponent();
            m_ServerAdress = serverAddress;
            m_ServerPort = serverPort;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Hide();
            var info = new RegisteredModeConnectSplashInfo(m_ServerAdress, m_ServerPort, txtUsername.Text, txtPassword.Text);
            if (new StepSplashForm(info).ShowDialog() == DialogResult.OK)
            {
                txtPassword.Text = "";
                new LobbyRegisteredModeForm(info.Server).ShowDialog();
                Close();
            }
            else
                Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnPlay.Enabled = !string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text);
        }
    }
}
