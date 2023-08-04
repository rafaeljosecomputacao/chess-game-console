using System;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.PutPart(new Tower(Color.Black, board), new Position(0, 0));
            board.PutPart(new Tower(Color.Black, board), new Position(1, 3));
            board.PutPart(new King(Color.Black, board), new Position(2, 4));

            Screen.PrintBoard(board);
        }
    }
}