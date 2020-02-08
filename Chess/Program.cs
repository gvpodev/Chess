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

                    Console.Write("Origin: ");
                    Position origin = View.ReadChessPosition().ToPosition();
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
