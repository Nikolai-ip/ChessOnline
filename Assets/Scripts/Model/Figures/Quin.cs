using System;
using System.Collections.Generic;

namespace ChessTest.Model.Figures
{

    public class Quin : Figure
    {
        public Quin(Field field) : base(field)
        {
        }

        protected override List<Tuple<int, int>> GetAllMoves(int i, int j)
        {
            List<Tuple<int, int>> moves = new();
            for (int k = 1; k < 8; k++)
            {
                moves.AddRange(GetDiagonalMoves(i, j, k));
                moves.AddRange(GetAxisMoves(i, k));

            }

            return moves;
        }

        private List<Tuple<int, int>> GetAxisMoves(int i, int k)
        {
            List<Tuple<int, int>> moves = new();
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

            return moves;
        }

        private List<Tuple<int, int>> GetDiagonalMoves(int i, int j, int k)
        {
            List<Tuple<int, int>> moves = new();
            for (int xDir = -1; xDir <= 1; xDir += 2)
            {
                for (int yDir = -1; yDir <= 1; yDir += 2)
                {
                    int newX = i + k * xDir;
                    int newY = j + k * yDir;
                    if ((newX >= 0 && newX <= 7) && (newY >= 0 && newY <= 7))
                        moves.Add(new Tuple<int, int>(newX, newY));
                }
            }

            return moves;
        }
    }
}