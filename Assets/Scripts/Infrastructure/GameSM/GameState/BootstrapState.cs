using GameCore;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using Infrastructure.Services.ServiceLocator;
using Network;
using StaticData;
using UnityEngine;

namespace Infrastructure.GameSM.GameState
{
    public class BootstrapState:IState
    {
        private const string InitialScene  = "Initial";
        private const string MainMenu = "MainMenu";
        private readonly GameStateMachine _gameSm;
        private readonly ISceneLoader _sceneLoader;
        private readonly GameServices _services;
        private bool _isInitialScene;
        public BootstrapState(GameStateMachine gameSm, ISceneLoader sceneLoader, GameServices gameServices)
        {
            _gameSm = gameSm;
            _sceneLoader = sceneLoader;
            _services = gameServices;
            RegisterServices();
            Application.targetFrameRate = 60;
        }
        public void Enter()
        {
            _sceneLoader.Load(InitialScene, ConnectToLobby);
        }

        private void ConnectToLobby()
        {
            _services.Single<ILobbyConnector>().OnLobbyConnected += OnLobbyConnected;
            _services.Single<ILobbyConnector>().LobbyConnect();
        }

        private void OnLobbyConnected()
        {
            _gameSm.Enter<MainMenu, string>(MainMenu);
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<INetworkAssetProvider>(new AssetProviderPhoton());
            _services.RegisterSingle<IStaticDataService>(new StaticDataService());
            _services.RegisterSingle<ISceneLoader>(_sceneLoader);
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<INetworkAssetProvider>(), _services.Single<IAssetProvider>()));
            var networkManager = _services.Single<IAssetProvider>().Instantiate(AssetPath.NetworkManager);
            Object.DontDestroyOnLoad(networkManager); 
            _services.RegisterSingle(networkManager.GetComponent<IRoomService>());
            _services.RegisterSingle(networkManager.GetComponent<ILobbyConnector>());
            
        }

        public void Exit()
        {
        }
    }
}