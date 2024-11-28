namespace ChessTest.Model
{

    public class ChessGame
    {
        private Field _field;
        public Side CurrentSide { get; private set; }
    
        public ChessGame(Field field)
        {
            _field = field;
            CurrentSide = Side.White;
        }

        public Field GetField() => _field;

        public Figure GetFigure(int i, int j)
        {
            return _field.data[i, j];
        }

        public void Attack(Figure attack, Figure defeated)
        {
            Move(attack, defeated.Coords.Y, defeated.Coords.X);
        }

        public void Move(Figure selectedFigure, int i, int j)
        {
            _field.data[i, j] = selectedFigure;
            CurrentSide = CurrentSide == Side.White ? Side.Black : Side.White;
        }
    }
}