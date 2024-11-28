using System;
using System.Collections.Generic;

namespace ChessTest.Model.Figures
{
    public class Pawn : Figure
    {
        private bool _isFirstMove = true;

        public Pawn(Field field) : base(field)
        {
        }

        protected override List<Tuple<int, int>> GetAllMoves(int i, int j)
        {
            List<Tuple<int, int>> moves = new();
            moves.Add(new Tuple<int, int>(i + 1, j));
            if (_isFirstMove)
            {
                moves.Add(new Tuple<int, int>(i + 2, j));
                _isFirstMove = false;
            }

            return moves;
        }

    }
}