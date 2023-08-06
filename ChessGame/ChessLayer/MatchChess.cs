using System;
using System.Collections.Generic;
using ChessGame.BoardLayer;
using ChessGame.ChessLayer;
using ChessGame.BoardLayer.Enums;
using ChessGame.BoardLayer.Exceptions;

namespace ChessGame.ChessLayer
{
    internal class MatchChess
    {
        private HashSet<Part> Parts;
        private HashSet<Part> Captured;
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
            Parts = new HashSet<Part>();
            Captured = new HashSet<Part>();
            PutParts();
        }

        private void PutParts()
        {
            PutNewPart('c', 1, new Tower(Board, Color.White));
            PutNewPart('c', 2, new Tower(Board, Color.White));
            PutNewPart('d', 2, new Tower(Board, Color.White));
            PutNewPart('e', 2, new Tower(Board, Color.White));
            PutNewPart('e', 1, new Tower(Board, Color.White));
            PutNewPart('d', 1, new King(Board, Color.White));

            PutNewPart('c', 7, new Tower(Board, Color.Black));
            PutNewPart('c', 8, new Tower(Board, Color.Black));
            PutNewPart('d', 7, new Tower(Board, Color.Black));
            PutNewPart('e', 7, new Tower(Board, Color.Black));
            PutNewPart('e', 8, new Tower(Board, Color.Black));
            PutNewPart('d', 8, new King(Board, Color.Black));
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
            if (capturedPart != null)
            {
                Captured.Add(capturedPart);
            }
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

        public void PutNewPart(char column, int line, Part part)
        {
            Board.PutPart(part, new PositionChess(column, line).ToPosition());
            Parts.Add(part);
        }

        public HashSet<Part> CapturedParts(Color color)
        {
            HashSet<Part> auxiliary = new HashSet<Part>();
            foreach (Part captured in Captured)
            {
                if (captured.Color == color)
                {
                    auxiliary.Add(captured);
                }
            }
            return auxiliary;
        }

        public HashSet<Part> PartsInGame(Color color)
        {
            HashSet<Part> auxiliary = new HashSet<Part>();
            foreach (Part part in Parts)
            {
                if (part.Color == color)
                {
                    auxiliary.Add(part);
                }
            }
            auxiliary.ExceptWith(CapturedParts(color));
            return auxiliary;
        }
    }
}