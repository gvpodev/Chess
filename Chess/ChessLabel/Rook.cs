using Chess.Board;
namespace Chess.ChessLabel
{
    public class Rook : Piece
    {
        public Rook(CBoard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}