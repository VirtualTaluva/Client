using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Com.Ericmas001.Windows;
using Com.Ericmas001.Windows.ViewModels;
using GalaSoft.MvvmLight.CommandWpf;
using VirtualTaluva.Client.DataTypes;
using VirtualTaluva.Client.Protocol;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;

namespace VirtualTaluva.ClientWpf.ViewModels
{
    class LobbyViewModel : BaseContentViewModel
    {
        private readonly string m_Name;
        private bool m_Identified = false;
        protected override string IconImageName => "Play";
        public override string BigLoadingMessage => "Starting QuickMode ...";
        private GameInfo m_Game;
        private TupleTable m_SelectedTable;
        public FastObservableCollection<TupleTable> Tables { get; } = new FastObservableCollection<TupleTable>();
        private RelayCommand m_DisconnectCommand;
        public ICommand DisconnectCommand => m_DisconnectCommand ?? (m_DisconnectCommand = new RelayCommand(OnDisconnectCommand));
        private RelayCommand m_CreateTableCommand;
        public ICommand CreateTableCommand => m_CreateTableCommand ?? (m_CreateTableCommand = new RelayCommand(OnCreateTableCommand));
        private RelayCommand m_JoinGameCommand;
        public ICommand JoinGameCommand => m_JoinGameCommand ?? (m_JoinGameCommand = new RelayCommand(OnJoinTableCommand));

        private readonly LobbyTcpClientQuickMode m_Server;
        public LobbyTcpClientQuickMode Server => m_Server;

        [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
        public bool? Success
        {
            get { return m_Success; }
            set
            {
                Set(ref m_Success, value);
                RaisePropertyChanged("IsSuccess");
                RaisePropertyChanged("IsError");
            }
        }

        public bool IsSuccess => m_Success.HasValue && m_Success.Value;
        public bool IsError => m_Success.HasValue && !m_Success.Value;

        public TupleTable SelectedTable
        {
            get { return m_SelectedTable; }
            set { Set(ref m_SelectedTable, value); }
        }

        private bool? m_Success = null;

        private void OnDisconnectCommand()
        {
            if (m_Server.IsConnected)
            {
                m_Server.ServerLost -= m_Server_ServerLost;
            }
            MainWindowViewModel.Instance.Connected = false;
        }

        public LobbyViewModel() : base(Dispatcher.CurrentDispatcher)
        {
            if (!(bool) (DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
                throw new Exception("Ctor intended for design mode only !!");
            m_Name = "PlayerName";
            Success = true;
        }

        public LobbyViewModel(string url, int port, string name) : base(Dispatcher.CurrentDispatcher)
        {
            m_Name = name;
            m_Server = new LobbyTcpClientQuickMode(url, port);
            MainWindowViewModel.Instance.Server = m_Server;
            RefreshDataAndInterface();
        }

        protected override void RefreshInterface()
        {
        }

        protected override void ObtainData(object sender, DoWorkEventArgs e)
        {
            Success = null;
            if (!m_Identified)
            {
                LoadingDataVm.SmallLoadingMessage = "Reaching the server ...";
                Thread.Sleep(1000);
                if (!m_Server.Connect())
                {
                    Success = false;
                    MessageBox.Show("Unreachable");
                    return;
                }

                m_Server.ServerLost += m_Server_ServerLost;
                m_Server.Start();

                LoadingDataVm.SmallLoadingMessage = "Checking Compatibility ...";
                Thread.Sleep(1000);
                var compat = m_Server.CheckServerCompatibility(typeof(App).Assembly.FullName);
                if (!compat.Success)
                {
                    Success = false;
                    MessageBox.Show($"{compat.MessageId}: {compat.Message}{Environment.NewLine}Server: {compat.ServerIdentification}{Environment.NewLine}Server protocol: {compat.ImplementedProtocolVersion}", "Server and client are not compatible");
                    return;
                }
                m_Game = compat.AvailableGames.FirstOrDefault();

                LoadingDataVm.SmallLoadingMessage = "Identifying the Player ...";
                Thread.Sleep(1000);
                if (!m_Server.Identify(m_Name))
                {
                    Success = false;
                    MessageBox.Show("Can't identify as " + m_Name);
                    return;
                }
                m_Identified = true;
            }

            LoadingDataVm.SmallLoadingMessage = "Getting List of tables ...";
            Thread.Sleep(1000);
            var tables = m_Server.ListTables(LobbyTypeEnum.QuickMode);
            if (tables == null)
            {
                Success = false;
                MessageBox.Show("Can't list tables!");
                return;
            }
            Tables.Clear();
            Tables.AddItems(tables);

            Success = true;
        }

        private void m_Server_ServerLost()
        {
            m_Server.ServerLost -= m_Server_ServerLost;
            if (MainWindowViewModel.Instance.Connected)
                MainWindowViewModel.Instance.Connected = false;
        }

        private void OnCreateTableCommand()
        {
            CreateNewTab(new CreateTableViewModel(m_Game));
        }

        private void OnJoinTableCommand()
        {
            CreateNewTab(new GameViewModel(SelectedTable.IdTable,SelectedTable.Params));
        }
    }
}