﻿using System;
using System.Collections.Generic;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;
using ChessGame.BoardLayer.Exceptions;

namespace ChessGame
{
    internal class Screen
    {
        public static void PrintMatch(MatchChess match)
        {
            PrintBoard(match.Board);

            Console.WriteLine();
            PrintCapturedParts(match);

            Console.WriteLine();
            Console.WriteLine("Shift: " + match.Shift);

            if (!match.Finished)
            {
                Console.WriteLine("Waiting move: " + match.CurrentPlayer);

                if (match.Check)
                {
                    ConsoleColor check = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Check");
                    Console.ForegroundColor = check;
                }
            }
            else
            {
                ConsoleColor checkmate = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Checkmate");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
                Console.ForegroundColor = checkmate;
            }         
        }

        public static void PrintCapturedParts(MatchChess match)
        {
            Console.WriteLine("Captured parts:");

            Console.Write("White: ");
            ConsoleColor white = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            PrintSet(match.CapturedParts(Color.White));
            Console.ForegroundColor = white;
            Console.WriteLine();

            Console.Write("Black: ");
            ConsoleColor black = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintSet(match.CapturedParts(Color.Black));
            Console.ForegroundColor = black;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Part> setParts)
        {
            Console.Write("[");
            foreach (Part part in setParts)
            {
                Console.Write(part + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                ConsoleColor numberColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(8 - i + " ");
                Console.ForegroundColor = numberColor;
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPart(board.Part(i, j));               
                }
                Console.WriteLine();
            }
            ConsoleColor letterColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("  a b c d e f g h");
            Console.ForegroundColor = letterColor;
        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.DarkCyan;

            for (int i = 0; i < board.Lines; i++)
            {
                ConsoleColor numberColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(part);
                    Console.ForegroundColor = originalColor;
                }
                else
                {
                    ConsoleColor originalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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