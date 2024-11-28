using ChessTest.Model.Figures;

namespace ChessTest.Model
{

    public class Field
    {
        public Figure[,] data;

        public Field()
        {
            data = new Figure[,]
            {
                {
                    new Tower(this), new Horse(this), new Elephant(this), new Quin(this), new King(this),
                    new Elephant(this), new Horse(this), new Tower(this)
                },
                {
                    new Pawn(this), new Pawn(this), new Pawn(this), new Pawn(this), new Pawn(this), new Pawn(this),
                    new Pawn(this), new Pawn(this)
                },
                {new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this),},
                {new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this),},
                {new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this),},
                {new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this), new NullFigure(this),},
                {
                new Pawn(this), new Pawn(this), new Pawn(this), new Pawn(this), new Pawn(this), new Pawn(this),
                new Pawn(this), new Pawn(this)
                },
                {
                    new Tower(this), new Horse(this), new Elephant(this), new Quin(this), new King(this),
                    new Elephant(this), new Horse(this), new Tower(this)
                }
                
            };
            foreach (var figure in data)
            {
                figure.Init();
            }
        }
    }
}