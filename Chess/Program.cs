using System;
using Chess.Board;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Position position = new Position(3, 4);

            Console.WriteLine("Position: "+ position);

            Console.ReadLine();
        }
    }
}
