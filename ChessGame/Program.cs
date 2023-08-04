using System;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;
using ChessGame.BoardLayer.Exceptions;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPart(new Tower(Color.Black, board), new Position(0, 0));
                board.PutPart(new Tower(Color.Black, board), new Position(1, 9));
                board.PutPart(new King(Color.Black, board), new Position(0, 2));

                Screen.PrintBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}