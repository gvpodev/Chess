using System;
using Chess.Board;
using Chess.ChessLabel;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition position = new ChessPosition('h', 1);
            Console.WriteLine(position);

            Console.WriteLine(position.ToPosition());

            Console.ReadLine();
        }
    }
}
