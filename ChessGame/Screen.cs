using System;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;
using ChessGame.BoardLayer.Exceptions;

namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                ConsoleColor numberColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = numberColor;
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPart(board.Part(i, j));               
                }
                Console.WriteLine();
            }
            ConsoleColor letterColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = letterColor;
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.Green;

            for (int i = 0; i < board.Lines; i++)
            {
                ConsoleColor numberColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = numberColor;
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPart(board.Part(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            ConsoleColor letterColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = letterColor;

            Console.BackgroundColor = originalBackground;
        }    

        public static void PrintPart(Part part)
        {
            if (part == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (part.Color == Color.White)
                {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(part);
                    Console.ForegroundColor = originalColor;
                }
                else
                {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(part);
                    Console.ForegroundColor = originalColor;
                }
                Console.Write(" ");
            }
        }

        public static PositionChess ReadPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }
    }
}