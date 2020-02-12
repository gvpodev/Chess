using System;
using System.Collections.Generic;
using Chess.Board;
namespace Chess.ChessLabel
{
    public class ChessGame
    {
        public CBoard board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool Check { get; private set; }

        public ChessGame()
        {
            board = new CBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExeMove(Position origin, Position destiny)
        {
            Piece piece = board.RemovePiece(origin);
            piece.IncreaseQtMoves();
            Piece CapturedPiece = board.RemovePiece(destiny);
            board.PlayPiece(piece, destiny);
            if (CapturedPiece != null)
            {
                captured.Add(CapturedPiece);
            }
            return CapturedPiece;
        }


        public void UndoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.RemovePiece(destiny);
            p.DecreaseQtMoves();

            if (capturedPiece != null)
            {
                board.PlayPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.PlayPiece(p, origin);
        }

        public void ExePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = ExeMove(origin, destiny);

            if (InCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, capturedPiece);
                throw new BoardException("You cannot get yourself in Checkmate.");
            }

            if (InCheck(Enemy(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            Turn++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            if(board.piece(position) == null)
            {
                throw new BoardException("There is no piece in the selected position.");
            }
            if(CurrentPlayer != board.piece(position).Color)
            {
                throw new BoardException("The origin piece does not belongs to you.");
            }
            if (!board.piece(position).ThereIsPossibleMoves())
            {
                throw new BoardException("There is no possible moves for your origin piece.");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position.");
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in pieces)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Enemy(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece x in InGamePieces(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool InCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("There is no King.");
            }

            foreach (Piece x in InGamePieces(Enemy(color)))
            {
                bool[,] matrix = x.PossibleMoves();
                if(matrix[K.Position.Row, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            board.PlayPiece(piece, new ChessPosition(column, row).ToPosition());
            pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Rook(board, Color.White));
            PutNewPiece('c', 2, new Rook(board, Color.White));
            PutNewPiece('d', 2, new Rook(board, Color.White));
            PutNewPiece('e', 2, new Rook(board, Color.White));
            PutNewPiece('e', 1, new Rook(board, Color.White));
            PutNewPiece('d', 1, new King(board, Color.White));

            PutNewPiece('c', 7, new Rook(board, Color.Black));
            PutNewPiece('c', 8, new Rook(board, Color.Black));
            PutNewPiece('d', 7, new Rook(board, Color.Black));
            PutNewPiece('e', 7, new Rook(board, Color.Black));
            PutNewPiece('e', 8, new Rook(board, Color.Black));
            PutNewPiece('d', 8, new King(board, Color.Black));
        }

    }
}
