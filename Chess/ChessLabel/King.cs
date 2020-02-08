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

        private bool CanMove(Position position)
        {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            //up
            p.DefineValues(Position.Row - 1, Position.Column);
            if(Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            //up&right
            p.DefineValues(Position.Row - 1, Position.Column + 1);
            if (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            //right
            p.DefineValues(Position.Row, Position.Column + 1);
            if (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            //down&right
            p.DefineValues(Position.Row + 1, Position.Column + 1);
            if (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            //down
            p.DefineValues(Position.Row + 1, Position.Column);
            if (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            //down&left
            p.DefineValues(Position.Row + 1, Position.Column - 1);
            if (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            //left
            p.DefineValues(Position.Row, Position.Column - 1);
            if (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            //up&left
            p.DefineValues(Position.Row - 1, Position.Column - 1);
            if (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
            }

            return matrix;
        }
    }
}
