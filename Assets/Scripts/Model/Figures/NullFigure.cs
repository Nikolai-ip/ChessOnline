using System;
using System.Collections.Generic;

namespace ChessTest.Model.Figures
{
    public class NullFigure:Figure
    {
        public NullFigure(Field field) : base(field)
        {
        }

        protected override List<Tuple<int, int>> GetAllMoves(int i, int j)
        {
            throw new NullReferenceException("Figure is null");
        }
    }
}