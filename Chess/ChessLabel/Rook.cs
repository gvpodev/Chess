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
            while(Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
                if (Board.piece(p) != null && Board.piece(p).Color != Color)
                {
                    break;
                }
                p.Row = p.Row - 1;
            }

            //down
            p.DefineValues(Position.Row + 1, Position.Column);
            while(Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
                if(Board.piece(p) != null && Board.piece(p).Color != Color)
                {
                    break;
                }
                p.Row = p.Row + 1;
            }

            //right
            p.DefineValues(Position.Row, Position.Column + 1);
            while(Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
                if(Board.piece(p) != null && Board.piece(p).Color != Color)
                {
                    break;
                }
                p.Column = p.Column + 1;
            }

            //left
            p.DefineValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(p) && CanMove(p))
            {
                matrix[p.Row, p.Column] = true;
                if (Board.piece(p) != null && Board.piece(p).Color != Color)
                {
                    break;
                }
                p.Column = p.Column - 1;
            }

            return matrix;
        }
    }
}