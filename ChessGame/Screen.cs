using System;
using ChessGame.BoardLayer;

namespace ChessGame
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                for(int j = 0; j < board.Columns; j++)
                {
                    if (board.Part(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Part(i, j) + " ");
                    }                  
                }
                Console.WriteLine();
            }
        }
    }
}