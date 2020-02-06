namespace Chess.Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMoves { get; protected set; }
        public CBoard Board { get; set; }

        public Piece(Position position, CBoard board, Color color)
        {
            Position = position;
            Board = board;
            Color = color;
            QtMoves = 0;
        }
    }
}
