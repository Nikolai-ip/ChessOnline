using System;
using System.Collections.Generic;

namespace ChessTest.Model.Figures
{
    public class Tower : Figure
    {

        public Tower(Field field) : base(field)
        {
        }

        protected override List<Tuple<int, int>> GetAllMoves(int i, int j)
        {
            List<Tuple<int, int>> moves = new();
            for (int k = 1; k < 8; k++)
            {
                for (int l = 0; l < 4; l++)
                {
                    int dX = l > 1 ? k : 0;
                    int dY = l <= 1 ? k : 0;
                    int sign = (int) Math.Pow(-1, l);
                    int newX = i + dX * sign;
                    int newY = i + dY * sign;
                    if ((newX >= 0 && newX <= 7) && (newY >= 0 && newY <= 7))
                        moves.Add(new Tuple<int, int>(newX, newY));
                }
            }

            return moves;
        }
    }
}