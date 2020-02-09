using System;
using Chess.Board;
using Chess.ChessLabel;
using System.Collections.Generic;
namespace Chess
{
    public class View
    {
        public static void PrintGame(ChessGame chessGame)
        {
            PrintBoard(chessGame.board);
            Console.WriteLine();
            PrintCapturedPieces(chessGame);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessGame.Turn);
            Console.WriteLine("Waiting play: " + chessGame.CurrentPlayer);
        }

        public static void PrintCapturedPieces(ChessGame chessGame)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintPieceSet(chessGame.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintPieceSet(chessGame.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintPieceSet(HashSet<Piece> set)
        {
            Console.Write("[ ");
            foreach(Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write(" ]");
        }

        public static void PrintBoard(CBoard board)
        {
            for(int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for(int j = 0; j < board.Columns; j++)
                {
                    
                    PrintPiece(board.piece(i, j));
                      
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(CBoard board, bool[,] possiblePositions)
        {
            ConsoleColor originalBG = Console.BackgroundColor;
            ConsoleColor alteredBG = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i,j])
                    {
                        Console.BackgroundColor = alteredBG;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBG;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBG;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBG;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + " ");

            return new ChessPosition(column, row);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {


                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
