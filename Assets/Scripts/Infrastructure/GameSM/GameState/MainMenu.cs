using GameCore;
using Infrastructure.Events;
using Infrastructure.SceneLoader;
using Network;
using UnityEngine;

namespace Infrastructure.GameSM.GameState
{
    public class MainMenu:IPayLoadedState<string>
    {
        private const string GameScene = "Game";
        private readonly ISceneLoader _sceneLoader;
        private readonly GameStateMachine _gameSM;
        private readonly IRoomService _roomService;

        public MainMenu(GameStateMachine gameStateMachine, IRoomService roomService, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _roomService = roomService;
            _gameSM = gameStateMachine;
           
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload);
            _roomService.RoomJoined += OnJoinRoom;
        }

        private void OnJoinRoom(string roomName)
        {
            _gameSM.Enter<LoadLevelState,string>(GameScene);
        }
        
        public void Exit()
        {
            _roomService.RoomJoined -= OnJoinRoom;
        }
    }
}