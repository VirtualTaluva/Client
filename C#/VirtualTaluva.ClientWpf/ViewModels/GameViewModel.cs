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
    class GameViewModel : BaseContentViewModel, IPokerViewer
    {
        protected override string IconImageName => "Controller";
        public override string BigLoadingMessage => "Joining game ...";

        public override string TabHeader => m_TableParms.TableName;
        public override bool CanCloseTab => true;
        private int m_TableId;
        private TableParams m_TableParms;

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

        private bool? m_Success = null;
        private RelayCommand m_LeaveTableCommand;
        public ICommand LeaveTableCommand => m_LeaveTableCommand ?? (m_LeaveTableCommand = new RelayCommand(OnLeaveTableCommand));

        public GameViewModel() : base(Dispatcher.CurrentDispatcher)
        {
            if (!(bool) (DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue))
                throw new Exception("Ctor intended for design mode only !!");
            m_TableParms = new TableParams {TableName = "Player's Table"};
            m_TableId = 0;
        }

        public GameViewModel(int id, TableParams parms) : base(Dispatcher.CurrentDispatcher)
        {
            m_TableId = id;
            m_TableParms = parms;
            OnRequestClose += GameViewModel_OnRequestClose;
            RefreshDataAndInterface();
        }

        private void GameViewModel_OnRequestClose(object sender, EventArgs e)
        {
            if (IsSuccess)
                MainWindowViewModel.Instance.Server.LeaveTable(m_TableId);
        }

        protected override void RefreshInterface()
        {
        }

        protected override void ObtainData(object sender, DoWorkEventArgs e)
        {
            Success = null;
            MainWindowViewModel.Instance.Server.JoinTable(m_TableId, m_TableParms.TableName, this);
            LoadingDataVm.SmallLoadingMessage = "Joining table ...";
            Thread.Sleep(1000);
            //if (!m_Identified)
            //{
            //    LoadingDataVm.SmallLoadingMessage = "Reaching the server ...";
            //    Thread.Sleep(1000);
            //    if (!m_Server.Connect())
            //    {
            //        Success = false;
            //        MessageBox.Show("Unreachable");
            //        return;
            //    }

            //    m_Server.ServerLost += m_Server_ServerLost;
            //    m_Server.Start();

            //    LoadingDataVm.SmallLoadingMessage = "Checking Compatibility ...";
            //    Thread.Sleep(1000);
            //    var compat = m_Server.CheckServerCompatibility(typeof(App).Assembly.FullName);
            //    if (!compat.Success)
            //    {
            //        Success = false;
            //        MessageBox.Show($"{compat.MessageId}: {compat.Message}{Environment.NewLine}Server: {compat.ServerIdentification}{Environment.NewLine}Server protocol: {compat.ImplementedProtocolVersion}", "Server and client are not compatible");
            //        return;
            //    }
            //    m_Game = compat.AvailableGames.FirstOrDefault();

            //    LoadingDataVm.SmallLoadingMessage = "Identifying the Player ...";
            //    Thread.Sleep(1000);
            //    if (!m_Server.Identify(m_Name))
            //    {
            //        Success = false;
            //        MessageBox.Show("Can't identify as " + m_Name);
            //        return;
            //    }
            //    m_Identified = true;
            //}

            //LoadingDataVm.SmallLoadingMessage = "Getting List of tables ...";
            //Thread.Sleep(1000);
            //var tables = m_Server.ListTables(LobbyTypeEnum.QuickMode);
            //if (tables == null)
            //{
            //    Success = false;
            //    MessageBox.Show("Can't list tables!");
            //    return;
            //}
            //Tables.Clear();
            //Tables.AddItems(tables);

            Success = true;
        }

        private void OnLeaveTableCommand()
        {
            CloseView();
        }

        public void SetGame(IPokerGame c)
        {
        }

        public void Start()
        {
        }
    }
}