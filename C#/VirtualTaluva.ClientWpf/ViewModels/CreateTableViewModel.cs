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
using VirtualTaluva.Client.Protocol;
using VirtualTaluva.Protocol.DataTypes;
using VirtualTaluva.Protocol.DataTypes.Enums;
using VirtualTaluva.Protocol.DataTypes.Options;

namespace VirtualTaluva.ClientWpf.ViewModels
{
    class CreateTableViewModel : BaseTabViewModel
    {
        public GameInfo Game { get; }
        protected override string IconImageName => "Plus";
        public override string TabHeader => "Create Table";
        public override bool CanCloseTab => true;

        private readonly LobbyTypeEnum m_LobbyType = LobbyTypeEnum.QuickMode;
        public IEnumerable<GameSubTypeEnum> GameTypes { get; }
        private RelayCommand m_CreateTableCommand;
        public ICommand CreateTableCommand => m_CreateTableCommand ?? (m_CreateTableCommand = new RelayCommand(OnCreateTableCommand));

        public string TableName
        {
            get { return m_TableName; }
            set { Set(ref m_TableName, value); }
        }

        public GameSubTypeEnum CurrentGameType
        {
            get { return m_CurrentGameType; }
            set { Set(ref m_CurrentGameType, value); }
        }

        public int MinPlayers
        {
            get { return m_MinPlayers; }
            set { Set(ref m_MinPlayers, value); }
        }

        public int MaxPlayers
        {
            get { return m_MaxPlayers; }
            set { Set(ref m_MaxPlayers, value); }
        }

        public int WaitingTimeAfterPlayerAction
        {
            get { return m_WaitingTimeAfterPlayerAction; }
            set { Set(ref m_WaitingTimeAfterPlayerAction, value); }
        }

        private string m_TableName;
        private GameSubTypeEnum m_CurrentGameType;
        private int m_MinPlayers;
        private int m_MaxPlayers;
        private int m_WaitingTimeAfterPlayerAction;

        public CreateTableViewModel(GameInfo game)
        {
            Game = game;
            GameTypes = game.AvailableVariants.OrderBy(x => (int)x).ToArray();
            CurrentGameType = GameTypes.FirstOrDefault();
            MinPlayers = game.MinPlayers;
            MaxPlayers = game.MaxPlayers;
            WaitingTimeAfterPlayerAction = 500;
            TableName = "Player's Table";
        }

        private void OnCreateTableCommand()
        {
            LobbyOptions lobby = null;
            switch (m_LobbyType)
            {
                case LobbyTypeEnum.QuickMode:
                    lobby = new LobbyOptionsQuickMode()
                    {
                        //StartingAmount = (int)nudStartingAmount.Value,
                    };
                    break;

                case LobbyTypeEnum.RegisteredMode:
                    lobby = new LobbyOptionsRegisteredMode()
                    {
                        //IsMaximumBuyInLimited = rdBuyInLimited.Checked,
                    };
                    break;
            }
            GameTypeOptions options = null;
            switch (Game.GameType)
            {
                case GameTypeEnum.Standard:
                    options = new GameTypeOptionsStandard();
                    break;
            }
            var parms = new TableParams
            {
                TableName = TableName,
                MaxPlayers = MaxPlayers,
                Lobby = lobby,
                Options = options,
                MinPlayersToStart = MinPlayers,
                Variant = CurrentGameType,
                WaitingTimes = new ConfigurableWaitingTimes
                {
                    AfterPlayerAction = WaitingTimeAfterPlayerAction
                }
            };
            int id = MainWindowViewModel.Instance.Server.CreateTable(parms);
            CreateNewTab(new GameViewModel(id,parms));
            CloseView();
        }

    }
}