using Infrastructure.Events;
using Infrastructure.SceneLoader;
using Infrastructure.Services.ServiceLocator;
using Signals;
using UnityEngine;

namespace DefaultNamespace
{
    public class RoomCreateButton:MonoBehaviour
    {
        public void OnClick()
        {
            EventBus.Invoke(new RoomCreateSignal());
        }
    }
}