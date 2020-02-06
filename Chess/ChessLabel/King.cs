using Chess.Board;
namespace Chess.ChessLabel
{
    public class King : Piece
    {
        public King(CBoard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
