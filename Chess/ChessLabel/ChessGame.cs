using System;
using Chess.Board;
namespace Chess.ChessLabel
{
    public class ChessGame
    {
        public CBoard board { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; set; }

        public ChessGame()
        {
            board = new CBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExeMove(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncreaseQtMoves();
            Piece CapturedPiece = board.RemovePiece(destiny);
            board.PlayPiece(piece, destiny);
        }

        private void PutPieces()
        {
            board.PlayPiece(new Rook(board, Color.White), new ChessPosition('c', 1).ToPosition());
            board.PlayPiece(new Rook(board, Color.White), new ChessPosition('c', 2).ToPosition());
            board.PlayPiece(new Rook(board, Color.White), new ChessPosition('d', 2).ToPosition());
            board.PlayPiece(new Rook(board, Color.White), new ChessPosition('e', 2).ToPosition());
            board.PlayPiece(new Rook(board, Color.White), new ChessPosition('e', 1).ToPosition());
            board.PlayPiece(new King(board, Color.White), new ChessPosition('d', 1).ToPosition());

            board.PlayPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).ToPosition());
            board.PlayPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).ToPosition());
            board.PlayPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).ToPosition());
            board.PlayPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).ToPosition());
            board.PlayPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).ToPosition());
            board.PlayPiece(new King(board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }

    }
}
