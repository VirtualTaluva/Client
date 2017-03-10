using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Com.Ericmas001.Windows.ViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using VirtualTaluva.Client.Protocol;

namespace VirtualTaluva.ClientWpf.ViewModels
{
    class LobbyViewModel : BaseContentViewModel
    {
        private readonly string m_Name;
        protected override string IconImageName => "Play";
        public override string BigLoadingMessage => "Starting QuickMode ...";

        private RelayCommand m_DisconnectCommand;
        public ICommand DisconnectCommand => m_DisconnectCommand ?? (m_DisconnectCommand = new RelayCommand(OnDisconnectCommand));

        private LobbyTcpClientQuickMode m_Server;
        public LobbyTcpClientQuickMode Server
        {
            get { return m_Server; }
        }
        private void OnDisconnectCommand()
        {
            if(m_Server.IsConnected)
                m_Server.Disconnect();
            MainWindowViewModel.Instance.Connected = false;
        }

        public LobbyViewModel(string url, int port, string name) : base(Dispatcher.CurrentDispatcher)
        {
            m_Name = name;
            m_Server = new LobbyTcpClientQuickMode(url, port);
            RefreshDataAndInterface();
        }

        protected override void RefreshInterface()
        {
        }

        protected override void ObtainData(object sender, DoWorkEventArgs e)
        {
            LoadingDataVm.SmallLoadingMessage = "Reaching the server ...";
            Thread.Sleep(1000);
            if (!m_Server.Connect())
            {
                MessageBox.Show("Unreachable");
                return;
            }

            m_Server.Start();

            LoadingDataVm.SmallLoadingMessage = "Checking Compatibility ...";
            Thread.Sleep(1000);
            var compat = m_Server.CheckServerCompatibility(typeof(App).Assembly.FullName);
            if (!compat.Success)
            {
                MessageBox.Show($"{compat.MessageId}: {compat.Message}{Environment.NewLine}Server: {compat.ServerIdentification}{Environment.NewLine}Server protocol: {compat.ImplementedProtocolVersion}", "Server and client are not compatible");
                return;
            }

            LoadingDataVm.SmallLoadingMessage = "Identifying the Player ...";
            Thread.Sleep(1000);
            if (!m_Server.Identify(m_Name))
            {
                MessageBox.Show("Can't identify as " + m_Name);
                return;
            }
            //var retry = true;
            //while (!isOk && retry)
            //{
            //    var form2 = new NameUsedForm(m_PlayerName);
            //    form2.ShowDialog();
            //    retry = form2.OK;
            //    m_PlayerName = form2.PlayerName;
            //    isOk = m_Server.Identify(m_PlayerName);
            //}
            //return isOk;
        }
    }
}
