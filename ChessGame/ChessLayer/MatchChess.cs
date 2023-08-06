using System;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;
using ChessGame.BoardLayer.Exceptions;

namespace ChessGame.ChessLayer
{
    internal class MatchChess
    {
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public Board Board { get; private set; }
        public bool Finished { get; private set; }

        public MatchChess()
        {
            Shift = 1;
            CurrentPlayer = Color.White;
            Board = new Board(8, 8);        
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
      
        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
           
        public void PerformsMove(Position origin, Position target)
        {
            ExecuteMove(origin, target);
            Shift++;
            ChangePlayer();
        }

        public void ExecuteMove(Position origin, Position target)
        {
            Part part = Board.RemovePart(origin);
            part.IncreaseQuantityMoves();
            Part capturedPart = Board.RemovePart(target);
            Board.PutPart(part, target);
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.Part(position) == null)
            {
                throw new BoardException("There is no part in the chosen origin position");
            }
            if (CurrentPlayer != Board.Part(position).Color)
            {
                throw new BoardException("The chosen origin part is not yours");
            }
            if (!Board.Part(position).ExistPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen origin part");
            }
        }

        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Part(origin).CanMoveTo(target))
            {
                throw new BoardException("Invalid target position");
            }
        }
    }
}