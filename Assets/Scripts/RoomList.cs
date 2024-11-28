using System.Collections.Generic;
using Infrastructure.Services.ServiceLocator;
using Network;
using Photon.Realtime;
using UnityEngine;

namespace DefaultNamespace
{
    public class RoomList:MonoBehaviour
    {
        private IRoomService _roomService;
        private List<RoomInfo> _roomInfos = new();
        private List<RoomItem> _roomItems = new();
        [SerializeField] private RoomItem _roomPref;

        private void Start()
        {
            Init(GameServices.Container.Single<IRoomService>());
        }

        public void Init(IRoomService roomService)
        {
            _roomService = roomService;
            _roomService.RoomListUpdated += RoomListUpdated;
        }
        
        private void RoomListUpdated(List<RoomInfo> roomInfos)
        {
            AddRoomsToList(roomInfos);
            if (_roomItems.Count>0)
                DestroyAllRooms();
            InstantiateRooms();
        }

        private void AddRoomsToList(List<RoomInfo> roomInfos)
        {
            foreach (var roomInfo in roomInfos)
                if (!_roomInfos.Contains(roomInfo))
                    _roomInfos.Add(roomInfo);
        }

        private void InstantiateRooms()
        {
            foreach (var roomInfo in _roomInfos)
            {
                var room = Instantiate(_roomPref, transform);
                room.SetRoomInfo(roomInfo);
                _roomItems.Add(room);
            }
        }

        private void DestroyAllRooms()
        {
            foreach (var roomItem in _roomItems)
                Destroy(roomItem);
        }
    }
}