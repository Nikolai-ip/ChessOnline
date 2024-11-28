using System;
using System.Collections.Generic;

namespace ChessTest.Model.Figures
{
    public class Elephant:Figure
    {
        public Elephant(Field field) : base(field)
        {
        }

        public override List<Tuple<int, int>> GetAvailableMoves()
        {
            var moves = GetAllMoves(Y, X);
            moves = RemoveAlies(moves);
            return moves;
        }

        protected override List<Tuple<int, int>> GetAllMoves(int i, int j)
        {
            List<Tuple<int, int>> moves = new();
            for (int k = 1; k < 8; k++)
            {
                for (int xDir = -1; xDir <= 1 ; xDir+=2)
                {
                    for (int yDir = -1; yDir <= 1 ; yDir+=2)
                    {
                        int newX = i + k * xDir;
                        int newY = j + k * yDir;
                        if ((newX>=0 && newX <=7) && (newY >=0 && newY<=7))
                            moves.Add(new Tuple<int, int>(newX,newY));
                    } 
                }
            }
        
            return moves;
        }


    }
}

