using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class Tower : Part
    {
        public Tower(Board board, Color color) : base(board, color) { }

        private bool CanMove(Position position)
        {
            Part part = Board.Part(position);
            return part == null || part.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //up
            position.SetValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;
            }

            //down
            position.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;
            }

            //right
            position.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            //left
            position.SetValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}