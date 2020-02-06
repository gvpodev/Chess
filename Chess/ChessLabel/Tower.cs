using Chess.Board;
namespace Chess.ChessLabel
{
    public class Tower : Piece
    {
        public Tower(CBoard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}