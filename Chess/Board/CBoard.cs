using System;
namespace Chess.Board
{
    public class CBoard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public CBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece piece(Position position)
        {
            return pieces[position.Row, position.Column];
        }

        public bool ExistPiece(Position position)
        {
            ValidatePosition(position);
            return piece(position) != null;
        }

        public void PlayPiece(Piece piece, Position position)
        {
            pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Row < 0 || position.Row >=Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position.");
            }
        }
    }
}
