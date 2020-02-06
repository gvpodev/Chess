using System;
using Chess.Board;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            CBoard board = new CBoard(8, 8);

            View.PrintBoard(board);

            Console.ReadLine();
        }
    }
}
