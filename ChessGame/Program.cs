﻿using System;
using ChessGame.BoardLayer;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position position = new Position(3, 4);
            Console.WriteLine("Position: " + position);
        }
    }
}