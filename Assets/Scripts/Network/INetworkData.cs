using System;
using Infrastructure.Services;

namespace Network
{
    public interface INetworkDataSender : IService
    {
        void SendAll<TData>(TData data) where TData : INetworkData;
        void SendOthers<TData>(TData data) where TData : INetworkData;
    }

    public interface INetworkDataReceiver : IService
    {
        void RegisterHandler<TData>(Action<TData> onDataReceived) where TData : INetworkData;
    }
    
    public interface INetworkData { }

    
}