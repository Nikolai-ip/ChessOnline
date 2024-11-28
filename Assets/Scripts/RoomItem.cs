using Infrastructure.Events;
using Photon.Realtime;
using Signals;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    internal class RoomItem:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _roomName;
        [SerializeField] private TextMeshProUGUI _playersCount;

        public void SetRoomInfo(RoomInfo roomInfo)
        {
            _roomName.text = roomInfo.Name;
            _playersCount.text = roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
        }

        public void OnClick()
        {
            EventBus.Invoke(new JoinRoomButtonClick(){RoomName = _roomName.text});
        }
    }
}