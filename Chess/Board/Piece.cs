namespace Chess.Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMoves { get; protected set; }
        public CBoard Board { get; set; }

        public Piece(CBoard board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            QtMoves = 0;
        }

        public void IncreaseQtMoves()
        {
            QtMoves++;
        }
    }
}
