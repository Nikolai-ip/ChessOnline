using ChessTest.Model;
using GameCore;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.SceneLoader;
using Infrastructure.Services.ServiceLocator;
using Network;
using Photon.Pun;
using Presenter;
using UnityEngine;

namespace Infrastructure.GameSM.GameState
{
    public class GameCycle : IPayLoadedState<GameServices>
    {
        private readonly GameStateMachine _gameStateMachine;
        private Field _field;
        private Grid _grid;
        private ChessGame _chessGame;
        private InputHandler _inputHandler;
        private Side _side;
        private IInputController _inputController;
        public GameCycle(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        public void Enter(GameServices gameServices)
        {
            _field = new Field();
            _chessGame = new ChessGame(_field);
            _grid = Object.FindObjectOfType<Grid>();
            _grid.CreateGrid();
            _inputController = gameServices.Single<IInputController>();
            _inputHandler = new InputHandler(_chessGame,_inputController);
            if (PhotonNetwork.IsMasterClient)
            {
                gameServices.Single<ChessFieldFactory>().CreateField(_grid,_field.data);
                _side = Side.White;
            }
            else
            {
                _side = Side.Black;
            }
        }

        public void Exit()
        {
        }
        
    }
}
