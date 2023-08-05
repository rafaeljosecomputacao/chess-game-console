using System;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                ConsoleColor numberColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = numberColor;
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Part(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPart(board.Part(i, j));
                        Console.Write(" ");
                    }                  
                }
                Console.WriteLine();
            }
            ConsoleColor letterColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = letterColor;
        }

        public static void PrintPart(Part part)
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
        }
    }
}