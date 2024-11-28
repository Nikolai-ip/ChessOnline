using System;
using System.Collections.Generic;
using Presenter;
using UnityEngine;

namespace ChessTest.View
{
    public class TilePainter:MonoBehaviour
    {
        private InputHandler _presenter;

        private void Start()
        {
            _presenter.OnAvailableMovesChanged += PaintTiles;
        }

        private void PaintTiles(List<Tuple<int, int>> moves)
        {
        
        }
    }
}
