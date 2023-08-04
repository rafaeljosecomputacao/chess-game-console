using System;
using ChessGame.BoardLayer;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Position position = new Position(3, 4);
            Console.WriteLine("Position: " + position);
        }
    }
}