using Infrastructure.Events;

namespace Signals
{
    public class JoinRoomButtonClick:ISignal
    {
        public string RoomName { get; set; }
    }
}