using System;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class MatchChess
    {
        private int Shift;
        private Color CurrentPlayer;
        public Board Board { get; private set; }
        public bool Finished { get; private set; }

        public MatchChess()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutParts();
        }

        private void PutParts()
        {
            Board.PutPart(new Tower(Board, Color.White), new PositionChess('c', 1).ToPosition());
            Board.PutPart(new Tower(Board, Color.White), new PositionChess('c', 2).ToPosition());
            Board.PutPart(new Tower(Board, Color.White), new PositionChess('d', 2).ToPosition());
            Board.PutPart(new Tower(Board, Color.White), new PositionChess('e', 2).ToPosition());
            Board.PutPart(new Tower(Board, Color.White), new PositionChess('e', 1).ToPosition());
            Board.PutPart(new King(Board, Color.White), new PositionChess('d', 1).ToPosition());

            Board.PutPart(new Tower(Board, Color.Black), new PositionChess('c', 7).ToPosition());
            Board.PutPart(new Tower(Board, Color.Black), new PositionChess('c', 8).ToPosition());
            Board.PutPart(new Tower(Board, Color.Black), new PositionChess('d', 7).ToPosition());
            Board.PutPart(new Tower(Board, Color.Black), new PositionChess('e', 7).ToPosition());
            Board.PutPart(new Tower(Board, Color.Black), new PositionChess('e', 8).ToPosition());
            Board.PutPart(new King(Board, Color.Black), new PositionChess('d', 8).ToPosition());
        }

        public void ExecuteMove(Position origin, Position target)
        {
            Part part = Board.RemovePart(origin);
            part.IncreaseQuantityMoves();
            Part capturedPart = Board.RemovePart(target);
            Board.PutPart(part, target);
        }
    }
}