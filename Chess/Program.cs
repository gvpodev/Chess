using System;
using Chess.Board;
using Chess.ChessLabel;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CBoard board = new CBoard(8, 8);

                board.PlayPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PlayPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PlayPiece(new King(board, Color.Black), new Position(0, 7));

                board.PlayPiece(new Rook(board, Color.White), new Position(3, 4));

                View.PrintBoard(board);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
