using GameCore;
using Infrastructure.SceneLoader;
using Infrastructure.Services;
using Infrastructure.Services.ServiceLocator;
using Network;

namespace Infrastructure
{
    internal class Game
    {
        public GameStateMachine StateMachine { get; }

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoaderPhoton(coroutineRunner), GameServices.Container);
        }
    }
}