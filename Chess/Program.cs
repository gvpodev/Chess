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
                    try
                    {
                        Console.Clear();
                        View.PrintGame(chessGame);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = View.ReadChessPosition().ToPosition();
                        chessGame.ValidateOriginPosition(origin);

                        bool[,] PossiblePositions = chessGame.board.piece(origin).PossibleMoves();

                        Console.Clear();
                        View.PrintBoard(chessGame.board, PossiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = View.ReadChessPosition().ToPosition();
                        chessGame.ValidateDestinyPosition(origin, destiny);

                        chessGame.ExePlay(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
