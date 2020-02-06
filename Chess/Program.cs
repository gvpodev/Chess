﻿using System;
using Chess.Board;
using Chess.ChessLabel;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            CBoard board = new CBoard(8, 8);

            board.PlayPiece(new Tower(board, Color.Black), new Position(0, 0));
            board.PlayPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.PlayPiece(new King(board, Color.Black), new Position(2, 4));

            View.PrintBoard(board);

            Console.ReadLine();
        }
    }
}
