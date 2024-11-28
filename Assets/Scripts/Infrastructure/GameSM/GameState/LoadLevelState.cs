using GameCore;
using Infrastructure.AssetManagement;
using Infrastructure.Events;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using Infrastructure.Services.ServiceLocator;
using Network;
using Photon.Pun;
using Signals;
using UnityEngine;

namespace Infrastructure.GameSM.GameState
{
    public class LoadLevelState : IPayLoadedState<string>, IState
    {
        private readonly GameStateMachine _gameSm;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly GameServices _services;

        public LoadLevelState(GameStateMachine gameStateMachine, GameServices services, ISceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameSm = gameStateMachine;
            _services = services;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _gameFactory = gameFactory;
        }
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }
        public void Exit()
        { }

        public void Enter()
        { }

        private void OnLoaded()
        {
            _gameFactory.CreateControllers();
            _gameFactory.CreateGameEntities();
            _gameSm.Enter<GameCycle, GameServices>(GameServices.Container);
            EventBus.Invoke(new SceneLoaded());
        }

    }
}