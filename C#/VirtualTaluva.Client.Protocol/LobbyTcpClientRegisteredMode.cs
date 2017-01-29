﻿using VirtualTaluva.DataTypes;
using VirtualTaluva.Protocol.Lobby;
using VirtualTaluva.Protocol.Lobby.RegisteredMode;

namespace VirtualTaluva.Client.Protocol
{
    public class LobbyTcpClientRegisteredMode : LobbyTcpClient
    {

        private UserInfo m_User;

        public UserInfo User { get { return m_User; } }

        public LobbyTcpClientRegisteredMode(string serverAddress, int serverPort)
            : base(serverAddress, serverPort)
        {
        }

        protected override JoinTableResponse GetJoinedSeat(int noPort, string player)
        {
            return base.GetJoinedSeat(noPort, m_User.Username);
        }

        public bool CheckUsernameAvailable(string username)
        {
            Send(new CheckUserExistCommand()
            {
                Username = username,
            });

            return !WaitAndReceive<CheckUserExistResponse>().Exist;
        }

        public bool CheckDisplayNameAvailable(string display)
        {
            Send(new CheckDisplayExistCommand()
            {
                DisplayName = display,
            });

            return !WaitAndReceive<CheckDisplayExistResponse>().Exist;
        }

        public bool CreateUser(string username, string password, string email, string displayname)
        {
            Send(new CreateUserCommand()
            {
                Username = username,
                Password = password,
                Email = email,
                DisplayName = displayname,
            });

            return WaitAndReceive<CreateUserResponse>().Success;
        }

        public bool Authenticate(string username, string password)
        {
            Send(new AuthenticateUserCommand()
            {
                Username = username,
                Password = password,
            });

            return WaitAndReceive<AuthenticateUserResponse>().Success;
        }

        public void RefreshUserInfo(string username)
        {
            Send(new GetUserCommand());

            var response = WaitAndReceive<GetUserResponse>();
            PlayerName = response.DisplayName;
            m_User = new UserInfo(username, "", response.Email, response.DisplayName, response.Money);
        }
    }
}
