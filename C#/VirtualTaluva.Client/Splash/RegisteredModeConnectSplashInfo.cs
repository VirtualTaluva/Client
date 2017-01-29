﻿using Com.Ericmas001.Windows.Forms;
using VirtualTaluva.Client.Protocol;
using System;

namespace VirtualTaluva.Client.Splash
{
    public class RegisteredModeConnectSplashInfo : StepSplashInfo
    {
        private readonly string m_ServerAddress;
        private readonly int m_ServerPort;
        private readonly string m_Username;
        private readonly string m_Password;

        private LobbyTcpClientRegisteredMode m_Server;

        public LobbyTcpClientRegisteredMode Server
        {
            get { return m_Server; }
        }

        public override string Title
        {
            get { return "Start Playing ..."; }
        }

        public override Tuple<BoolEmptyHandler, string>[] Steps
        {
            get
            {
                return new[]
                {
                    new Tuple<BoolEmptyHandler, string>(ExecuteStep1ReachingServer, "Reaching the server ..."),
                    new Tuple<BoolEmptyHandler, string>(ExecuteStep2CheckUsernameExistence, "Existence of Username ..."),
                    new Tuple<BoolEmptyHandler, string>(ExecuteStep3Authenticate, "Authenticating Player ..."),
                    new Tuple<BoolEmptyHandler, string>(ExecuteStep4RetrieveUserInfo, "Retrieving User Info ...")
                };
            }
        }

        public RegisteredModeConnectSplashInfo(string serverAddress, int serverPort, string username, string password)
        {
            m_Password = password;
            m_Username = username;
            m_ServerAddress = serverAddress;
            m_ServerPort = serverPort;
        }

        private bool ExecuteStep1ReachingServer()
        {
            return m_Server.Connect();
        }

        private bool ExecuteStep2CheckUsernameExistence()
        {
            m_Server.Start();
            return !m_Server.CheckUsernameAvailable(m_Username);
        }

        private bool ExecuteStep3Authenticate()
        {
            return m_Server.Authenticate(m_Username, m_Password);
        }

        private bool ExecuteStep4RetrieveUserInfo()
        {
            m_Server.RefreshUserInfo(m_Username);
            return true;
        }

        public override void Init()
        {
            m_Server = new LobbyTcpClientRegisteredMode(m_ServerAddress, m_ServerPort);
        }
    }
}
