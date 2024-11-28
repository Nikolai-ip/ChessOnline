using System;
using Infrastructure.Services;

namespace Infrastructure.SceneLoader
{
    public interface ISceneLoader:IService
    {
        void Load(string name, Action onLoaded = null);
        string CurrentScene { get; }
    }
}