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
        public bool Check { get; private set; }
        public Part VulnerableEnPassant { get; private set; }

        public MatchChess()
        {
            Shift = 1;
            CurrentPlayer = Color.White;
            Board = new Board(8, 8);        
            Finished = false;
            Check = false;
            VulnerableEnPassant = null;
            Parts = new HashSet<Part>();
            Captured = new HashSet<Part>();
            PutParts();
        }

        private void PutParts()
        {
            PutNewPart('a', 1, new Tower(Board, Color.White));
            PutNewPart('b', 1, new Horse(Board, Color.White));
            PutNewPart('c', 1, new Bishop(Board, Color.White));
            PutNewPart('d', 1, new Queen(Board, Color.White));
            PutNewPart('e', 1, new King(Board, Color.White, this));
            PutNewPart('f', 1, new Bishop(Board, Color.White));
            PutNewPart('g', 1, new Horse(Board, Color.White));
            PutNewPart('h', 1, new Tower(Board, Color.White));
            PutNewPart('a', 2, new Pawn(Board, Color.White, this));
            PutNewPart('b', 2, new Pawn(Board, Color.White, this));
            PutNewPart('c', 2, new Pawn(Board, Color.White, this));
            PutNewPart('d', 2, new Pawn(Board, Color.White, this));
            PutNewPart('e', 2, new Pawn(Board, Color.White, this));
            PutNewPart('f', 2, new Pawn(Board, Color.White, this));
            PutNewPart('g', 2, new Pawn(Board, Color.White, this));
            PutNewPart('h', 2, new Pawn(Board, Color.White, this));

            PutNewPart('a', 8, new Tower(Board, Color.Black));
            PutNewPart('b', 8, new Horse(Board, Color.Black));
            PutNewPart('c', 8, new Bishop(Board, Color.Black));
            PutNewPart('d', 8, new Queen(Board, Color.Black));
            PutNewPart('e', 8, new King(Board, Color.Black, this));
            PutNewPart('f', 8, new Bishop(Board, Color.Black));
            PutNewPart('g', 8, new Horse(Board, Color.Black));
            PutNewPart('h', 8, new Tower(Board, Color.Black));
            PutNewPart('a', 7, new Pawn(Board, Color.Black, this));
            PutNewPart('b', 7, new Pawn(Board, Color.Black, this));
            PutNewPart('c', 7, new Pawn(Board, Color.Black, this));
            PutNewPart('d', 7, new Pawn(Board, Color.Black, this));
            PutNewPart('e', 7, new Pawn(Board, Color.Black, this));
            PutNewPart('f', 7, new Pawn(Board, Color.Black, this));
            PutNewPart('g', 7, new Pawn(Board, Color.Black, this));
            PutNewPart('h', 7, new Pawn(Board, Color.Black, this));
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

        private Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Part WhoIsKing(Color color)
        {
            foreach (Part part in PartsInGame(color))
            {
                if (part is King)
                {
                    return part;
                }
            }
            return null;
        }

        public void PerformsMove(Position origin, Position target)
        {
            Part capturedPart = ExecuteMove(origin, target);

            if (IsCheck(CurrentPlayer))
            {
                UndoMove(origin, target, capturedPart);
                throw new BoardException("You can't put yourself in check");
            }

            if (IsCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheck(Adversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
            }

            //en passant
            Part part = Board.Part(target);
            if (part is Pawn && (target.Line == origin.Line - 2 || target.Line == origin.Line + 2))
            {
                VulnerableEnPassant = part;
            }
            else
            {
                VulnerableEnPassant = null;
            }
        }

        public Part ExecuteMove(Position origin, Position target)
        {
            Part part = Board.RemovePart(origin);
            part.IncreaseQuantityMoves();
            Part capturedPart = Board.RemovePart(target);
            Board.PutPart(part, target);
            if (capturedPart != null)
            {
                Captured.Add(capturedPart);
            }

            //short castling
            if (part is King && target.Column == origin.Column + 2)
            {
                Position originTower = new Position(origin.Line, origin.Column + 3);
                Position targetTower = new Position(origin.Line, origin.Column + 1);
                Part tower = Board.RemovePart(originTower);
                tower.IncreaseQuantityMoves();
                Board.PutPart(tower, targetTower);
            }

            //long castling
            if (part is King && target.Column == origin.Column - 2)
            {
                Position originTower = new Position(origin.Line, origin.Column - 4);
                Position targetTower = new Position(origin.Line, origin.Column - 1);
                Part tower = Board.RemovePart(originTower);
                tower.IncreaseQuantityMoves();
                Board.PutPart(tower, targetTower);
            }

            //en passant
            if (part is Pawn)
            {
                if (origin.Column != target.Column && capturedPart == null)
                {
                    Position positionPawn;
                    if (part.Color == Color.White)
                    {
                        positionPawn = new Position(target.Line + 1, target.Column);
                    }
                    else
                    {
                        positionPawn = new Position(target.Line - 1, target.Column);
                    }
                    capturedPart = Board.RemovePart(positionPawn);
                    Captured.Add(capturedPart);
                }
            }

            return capturedPart;
        }

        public void UndoMove(Position origin, Position target, Part capturedPart)
        {
            Part part = Board.RemovePart(target);
            part.DecrementQuantityMoves();         
            if (capturedPart != null)
            {
                Board.PutPart(capturedPart, target);
                Captured.Remove(capturedPart);
            }
            Board.PutPart(part, origin);

            //short castling
            if (part is King && target.Column == origin.Column + 2)
            {
                Position originTower = new Position(origin.Line, origin.Column + 3);
                Position targetTower = new Position(origin.Line, origin.Column + 1);
                Part tower = Board.RemovePart(targetTower);
                tower.DecrementQuantityMoves();
                Board.PutPart(tower, originTower);
            }

            //long castling
            if (part is King && target.Column == origin.Column - 2)
            {
                Position originTower = new Position(origin.Line, origin.Column - 4);
                Position targetTower = new Position(origin.Line, origin.Column - 1);
                Part tower = Board.RemovePart(targetTower);
                tower.DecrementQuantityMoves();
                Board.PutPart(tower, originTower);
            }

            //en passant
            if (part is Pawn)
            {
                if (origin.Column != target.Column && capturedPart == VulnerableEnPassant)
                {
                    Part pawn = Board.RemovePart(target);
                    Position positionPawn;
                    if (part.Color == Color.White)
                    {
                        positionPawn = new Position(3, target.Column);
                    }
                    else
                    {
                        positionPawn = new Position(4, target.Column);
                    }
                    Board.PutPart(pawn, positionPawn);
                }
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

        public bool IsCheck(Color color)
        {
            Part king = WhoIsKing(color);
            if (king == null)
            {
                throw new BoardException("There is no " + color + " King on the board");
            }
            foreach (Part part in PartsInGame(Adversary(color)))
            {
                bool[,] matrix = part.PossibleMoves();
                if (matrix[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheck(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach (Part part in PartsInGame(color))
            {
                bool[,] matrix = part.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++) 
                { 
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = part.Position;
                            Position target = new Position(i, j);
                            Part capturedPart = ExecuteMove(origin, target);
                            bool testCheck = IsCheck(color);
                            UndoMove(origin, target, capturedPart);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}