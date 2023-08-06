using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class Horse : Part
    {
        public Horse(Board board, Color color) : base(board, color) { }

        private bool CanMove(Position position)
        {
            Part part = Board.Part(position);
            return part == null || part.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMoves = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            position.SetValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            position.SetValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                possibleMoves[position.Line, position.Column] = true;
            }

            return possibleMoves;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}