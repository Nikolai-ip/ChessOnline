using System;
using System.Collections.Generic;

namespace ChessTest.Model
{
    public abstract class Figure
    {
        protected Side Side;
        protected Field Field;
        protected int X;
        protected int Y;
        public Coords Coords => new (X, Y);
        public Side GetSide => Side;
        protected Figure(Field field)
        {
            Field = field;
        }
    
        public void Init()
        {
            for (int i = 0; i < Field.data.GetLength(0); i++)
            {
                for (int j = 0; j < Field.data.GetLength(1); j++)
                {
                    if (Field.data[i, j] == this)
                    {
                        Y = i;
                        X = j;
                        Side = Y < 4 ? Side.Black : Side.White;
                        return;
                    }
                }
            }
        }
    
        public virtual List<Tuple<int, int>> GetAvailableMoves()
        {
            var moves = GetAllMoves(Y, X);
            moves = RemoveAlies(moves);
            return moves;
        }
    
        protected abstract List<Tuple<int, int>> GetAllMoves(int i, int j);
        protected List<Tuple<int, int>> RemoveAlies(List<Tuple<int, int>> moves)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                if (Field.data[moves[i].Item1, moves[i].Item2].GetSide == Side)
                {
                    moves.RemoveAt(i);
                }
            }
            return moves;
        }
    }
    

    public enum Side
    {
        White,
        Black
    }

}
