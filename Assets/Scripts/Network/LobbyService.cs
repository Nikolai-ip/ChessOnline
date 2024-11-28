using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Network
{
    public class LobbyService:MonoBehaviourPunCallbacks,ILobbyConnector
    {
        public void LobbyConnect()
        {
            Debug.Log("Lobby connect...");
            if (PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.JoinLobby();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings();
            }
        }
        public override void OnJoinedLobby()
        {
            Debug.Log("Lobby Joined");
            OnLobbyConnected?.Invoke();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Server connected");
            PhotonNetwork.JoinLobby();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            OnLobbyDisconnected?.Invoke();
        }

        public event Action OnLobbyConnected;
        public event Action OnLobbyDisconnected;
    }
}