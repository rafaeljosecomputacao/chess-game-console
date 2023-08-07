using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class King : Part
    {
        private MatchChess match;
        public King(Board board, Color color, MatchChess matchChess) : base(board, color) 
        {
            this.match = matchChess;
        }

        private bool CanMove(Position position)
        {
            Part part = Board.Part(position);
            return part == null || part.Color != Color;
        }

        private bool TestTowerToRocket(Position position)
        {
            Part part = Board.Part(position);
            return part != null && part is Tower && part.Color == Color && part.QuantityMoves == 0;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //up
            position.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //north east
            position.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //right
            position.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //south east
            position.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //down
            position.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //south west
            position.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //left
            position.SetValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //north west
            position.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            //rocket
            if (QuantityMoves == 0 && !match.Check)
            {
                //short castling
                Position positionTower1 = new Position(Position.Line, Position.Column + 3);
                if (TestTowerToRocket(positionTower1))
                {
                    Position position1 = new Position(Position.Line, Position.Column + 1);
                    Position position2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Part(position1) == null && Board.Part(position2) == null)
                    {
                        possibleMoves[Position.Line, Position.Column + 2] = true;
                    }
                }

                //long castling
                Position positionTower2 = new Position(Position.Line, Position.Column - 4);
                if (TestTowerToRocket(positionTower2))
                {
                    Position position1 = new Position(Position.Line, Position.Column - 1);
                    Position position2 = new Position(Position.Line, Position.Column - 2);
                    Position position3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Part(position1) == null && Board.Part(position2) == null && Board.Part(position3) == null)
                    {
                        possibleMoves[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}