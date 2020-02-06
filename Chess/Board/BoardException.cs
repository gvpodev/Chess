using System;
namespace Chess.Board
{
    public class BoardException : Exception
    {
        public BoardException(string msg) : base(msg)
        {

        }
    }
}
