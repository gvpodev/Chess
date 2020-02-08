namespace Chess.Board
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtMoves { get; protected set; }
        public CBoard PieceBoard { get; set; }

        public Piece(CBoard board, Color color)
        {
            Position = null;
            PieceBoard = board;
            Color = color;
            QtMoves = 0;
        }

        public abstract bool[,] PossibleMoves();
    

        public void IncreaseQtMoves()
        {
            QtMoves++;
        }
    }
}
