using Infrastructure.Events;
using Infrastructure.SceneLoader;
using Infrastructure.Services.ServiceLocator;
using Network;
using Photon.Realtime;
using Signals;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class RoomController:MonoBehaviour
    {
        private IRoomService _roomService;
        [SerializeField] private TMP_InputField _roomNameUI;

        private void Start()
        {
            Init(GameServices.Container.Single<IRoomService>());
        }

        public void Init(IRoomService roomService)
        {
            _roomService = roomService;
            _roomService.RoomJoined += OnRoomJoined;
            EventBus.Subscribe<RoomCreateSignal>(OnRoomCreateButton);
            EventBus.Subscribe<JoinRoomButtonClick>(OnJoinButtonClick);
        }

        private void OnRoomJoined(string obj)
        {
        }

        private void OnJoinButtonClick(JoinRoomButtonClick signal)
        {
            if (_roomService.CurrentRoom == null || _roomService.CurrentRoom.Name != signal.RoomName)
                _roomService.JoinRoom(signal.RoomName);
        }
        
        private void OnRoomCreateButton(RoomCreateSignal roomCreateButton)
        {
            if (_roomNameUI.text != "")
            {
                _roomService.CreateRoom(_roomNameUI.text, new RoomOptions());
            }
        }

    }
}