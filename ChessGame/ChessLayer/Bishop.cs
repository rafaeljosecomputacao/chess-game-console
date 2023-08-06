using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class Bishop : Part
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        private bool CanMove(Position position)
        {
            Part part = Board.Part(position);
            return part == null || part.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //north west
            position.SetValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line - 1, position.Column - 1);
            }

            //north east
            position.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line - 1, position.Column + 1);
            }

            //south east
            position.SetValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line + 1, position.Column + 1);
            }

            //south west
            position.SetValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
                if (Board.Part(position) != null && Board.Part(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Line + 1, position.Column - 1);
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}