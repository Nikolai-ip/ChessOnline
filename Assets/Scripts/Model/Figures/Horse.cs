using System;
using System.Collections.Generic;

namespace ChessTest.Model.Figures
{
    public class Horse:Figure
    {
        public Horse( Field field) : base(field)
        {
        }
        protected override List<Tuple<int, int>> GetAllMoves(int i, int j)
        {
            List<Tuple<int, int>> moves = new();
            for (int k = 0; k < 2; k++)
            {
                for (int xDir = -1; xDir <= 1; xDir += 2)
                {
                    for (int yDir = -1; yDir <= 1; yDir += 2)
                    {   
                        int newX = i + xDir * (2 - k);
                        int newY = j + yDir * (k + 1);
                        if ((newX>=0 && newX <=7) && (newY >=0 && newY<=7))
                            moves.Add(new Tuple<int, int>(newX,newY));
                    }
                }
            }
            return moves;
        }
    }
}

