using System;
using Infrastructure.Services;

namespace Network
{
    public interface ILobbyConnector:IService
    {
        public void LobbyConnect();
        public event Action OnLobbyConnected;
        public event Action OnLobbyDisconnected;

    }
}