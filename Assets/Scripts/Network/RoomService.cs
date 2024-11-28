using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

namespace Network
{
    public class RoomService:MonoBehaviourPunCallbacks, IRoomService
    {
        private string _createdRoomName;
        private string _joinedRoomName;
        
        public event Action<string> RoomCreated;
        public event Action<string> RoomJoined;
        public event Action<string> RoomJoinFailed;
        public event Action<List<RoomInfo>> RoomListUpdated;
        public event Action OnRoomLeft;
        public event Action<Player> PlayerJoined;
        public event Action<Player> OnPlayerLeft;

        public Room CurrentRoom => PhotonNetwork.CurrentRoom;
        public void CreateRoom(string roomName, RoomOptions roomOptions)
        {
            _createdRoomName = roomName;
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        public void JoinRoom(string roomName)
        {
            _joinedRoomName = roomName;
            PhotonNetwork.JoinRoom(roomName);
        }
        public override void OnCreatedRoom()
        {
            RoomCreated?.Invoke(_createdRoomName);
        }

        public override void OnJoinedRoom()
        {
            RoomJoined?.Invoke(PhotonNetwork.CurrentRoom.Name);
        }
        public override void OnLeftRoom()
        {
            OnRoomLeft?.Invoke();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            RoomListUpdated?.Invoke(roomList);
        }
        
        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            RoomJoinFailed?.Invoke(_joinedRoomName);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            OnPlayerLeft?.Invoke(otherPlayer);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            PlayerJoined?.Invoke(newPlayer);
        }
    }
}