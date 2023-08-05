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
                MatchChess match = new MatchChess();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();
                    Console.Write("Target: ");
                    Position target = Screen.ReadPositionChess().ToPosition();

                    match.ExecuteMove(origin, target);
                }              
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}