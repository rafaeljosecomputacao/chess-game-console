using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class Pawn : Part
    {
        private MatchChess match;
        public Pawn(Board board, Color color, MatchChess matchChess) : base(board, color)
        {
            this.match = matchChess;
        }

        private bool ExistEnemy(Position position)
        {
            Part part = Board.Part(position);
            return part != null && part.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.Part(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                position.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line - 2, Position.Column);
                Position position2 = new Position(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position2) && Free(position2) && Board.ValidPosition(position) && Free(position) && QuantityMoves == 0)
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                //en passant
                if (Position.Line == 3)
                {
                    //left
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.Part(left) == match.VulnerableEnPassant)
                    {
                        possibleMoves[left.Line - 1, left.Column] = true;
                    }

                    //right
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistEnemy(right) && Board.Part(right) == match.VulnerableEnPassant)
                    {
                        possibleMoves[right.Line - 1, right.Column] = true;
                    }
                }              
            }
            else
            {
                position.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line + 2, Position.Column);
                Position position2 = new Position(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position2) && Free(position2) && Board.ValidPosition(position) && Free(position) && QuantityMoves == 0)
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                position.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ExistEnemy(position))
                {
                    possibleMoves[position.Line, position.Column] = true;
                }

                //en passant
                if (Position.Line == 4)
                {
                    //left
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistEnemy(left) && Board.Part(left) == match.VulnerableEnPassant)
                    {
                        possibleMoves[left.Line + 1, left.Column] = true;
                    }

                    //right
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistEnemy(right) && Board.Part(right) == match.VulnerableEnPassant)
                    {
                        possibleMoves[right.Line + 1, right.Column] = true;
                    }
                }
            }
            
            return possibleMoves;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}