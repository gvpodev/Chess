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

        public bool ThereIsPossibleMoves()
        {
            bool[,] matrix = PossibleMoves();
            for(int i = 0; i < PieceBoard.Rows; i++)
            {
                for (int j = 0; j < PieceBoard.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
