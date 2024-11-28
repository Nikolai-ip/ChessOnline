using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Photon.Realtime;

namespace Network
{
    public interface IRoomService: IService, IRoomCreator, IRoomJoiner, IRoomLefter
    {
        event Action<List<RoomInfo>> RoomListUpdated;
        Room CurrentRoom { get; }
    }
    public interface IRoomCreator
    {
        void CreateRoom(string roomName, RoomOptions roomOptions);
        event Action<string> RoomCreated;
    }

    public interface IRoomJoiner
    {
        void JoinRoom(string roomName);
        event Action<string> RoomJoined;
        event Action<string> RoomJoinFailed;
        event Action<Player> PlayerJoined;
    }

    public interface IRoomLefter
    {
        event Action OnRoomLeft;
        event Action<Player> OnPlayerLeft;
    }

}