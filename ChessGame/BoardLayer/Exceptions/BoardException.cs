using System;

namespace ChessGame.BoardLayer.Exceptions
{
    internal class BoardException : ApplicationException
    {
        public BoardException(string message) : base(message) { }
    }
}