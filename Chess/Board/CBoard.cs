﻿using System;
namespace Chess.Board
{
    public class CBoard
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] pieces;

        public CBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public void PlayPiece(Piece piece, Position position)
        {
            pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
    }
}
