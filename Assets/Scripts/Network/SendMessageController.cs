using System;
using Photon.Pun;
using UnityEngine;
using System.Collections.Generic;
using Network;
using TMPro;

public class SendMessageController : MonoBehaviour, INetworkDataSender, INetworkDataReceiver
{
    private PhotonView _photonView;
    private readonly Dictionary<Type, List<Action<string>>> _handlers = new ();
    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }
    public void SendAll<TData>(TData data) where TData : INetworkData
    {
        string json = JsonUtility.ToJson(data);
        _photonView.RPC(nameof(Receive), RpcTarget.All, typeof(TData).AssemblyQualifiedName, json);
    }

    public void SendOthers<TData>(TData data) where TData : INetworkData
    {
        string json = JsonUtility.ToJson(data);
        _photonView.RPC(nameof(Receive), RpcTarget.Others, typeof(TData).AssemblyQualifiedName, json);
    }
    
    public void RegisterHandler<TData>(Action<TData> onDataReceived) where TData : INetworkData
    {
        var type = typeof(TData);

        if (!_handlers.ContainsKey(type))
        {
            _handlers[type] = new List<Action<string>>();
        }

        _handlers[type].Add(jsonData =>
        {
            var data = JsonUtility.FromJson<TData>(jsonData);
            onDataReceived?.Invoke(data);
        });
    }

    [PunRPC]
    public void Receive(string typeName, string jsonData)
    {
        Type dataType = Type.GetType(typeName);
        if (dataType != null && _handlers.TryGetValue(dataType, out var handlers))
        {
            foreach (var handler in handlers)
            {
                handler(jsonData);
            }
        }
    }
}