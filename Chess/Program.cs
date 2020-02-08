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
                ChessGame chessGame = new ChessGame();

                while (!chessGame.Finished)
                {
                    Console.Clear();
                    View.PrintBoard(chessGame.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = View.ReadChessPosition().ToPosition();

                    bool[,] PossiblePositions = chessGame.board.piece(origin).PossibleMoves();

                    Console.Clear();
                    View.PrintBoard(chessGame.board, PossiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = View.ReadChessPosition().ToPosition();

                    chessGame.ExeMove(origin, destiny);
                }


            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
