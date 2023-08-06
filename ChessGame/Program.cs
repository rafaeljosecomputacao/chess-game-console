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
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(match.Board);

                        Console.WriteLine();
                        Console.WriteLine("Shift: " + match.Shift);
                        Console.WriteLine("Waiting move: " + match.CurrentPlayer);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPositionChess().ToPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = match.Board.Part(origin).PossibleMoves();
                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Target: ");
                        Position target = Screen.ReadPositionChess().ToPosition();
                        match.ValidateTargetPosition(origin, target);

                        match.PerformsMove(origin, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }              
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}