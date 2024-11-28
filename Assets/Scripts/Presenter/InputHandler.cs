using System;
using System.Collections.Generic;
using ChessTest.Model;

namespace Presenter
{
    public class InputHandler
    {
        private ChessGame _chessGame;
        private Figure _figure;
        private List<Tuple<int, int>> _availableMoves = new();
        private Side _playerSide;
        private readonly IInputController _inputController;

        public InputHandler(ChessGame chessGame, IInputController inputController)
        {
            _inputController = inputController;
            _chessGame = chessGame;
            _inputController.TileSelected += OnTileSelected;
        }
        

        public List<Tuple<int, int>> AvailableMoves
        {
            get => _availableMoves;
            set
            {
                _availableMoves = value;
                OnAvailableMovesChanged?.Invoke(_availableMoves);
            }
        }
    
        private bool FigureIsSelected => _figure != null;
    
        public event Action<List<Tuple<int, int>>> OnAvailableMovesChanged;
    
        public event Action<Figure, Figure> OnFigureAttack;
        public event Action<Field> OnFieldChanged;
        
    
        public void OnTileSelected(int x, int y)
        {
            if (!FigureIsSelected)
            {
                SelectFigure(y,x);
            }
            else if (AvailableMoves.Contains(new Tuple<int, int>(y,x)))
            {
                PerformActionOnTile(y, x);
                OnFieldChanged?.Invoke(_chessGame.GetField());
            }
            else
            {
                ClearSelectedFigure();
            }
        }
    
        private void SelectFigure(int y, int x)
        {
            var figure =  _chessGame.GetFigure(y, x);
            if (figure.GetSide == _playerSide)
            {
                _figure = figure;
                AvailableMoves = _figure.GetAvailableMoves();
            }
        }
    
        private void PerformActionOnTile(int y, int x)
        {
            var enemyFigure = _chessGame.GetFigure(y, x);
            if (enemyFigure != null)
            {
                _chessGame.Attack(_figure, enemyFigure);
                OnFigureAttack?.Invoke(_figure,enemyFigure);
            }
            else
            {
                _chessGame.Move(_figure, y, x);
            }
        }
    
        public void ClearSelectedFigure()
        {
            _figure = null;
            AvailableMoves.Clear();
        }
    }
}

