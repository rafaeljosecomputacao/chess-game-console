using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class King : Part
    {
        public King(Board board, Color color) : base(board, color) { }

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

            return possibleMoves;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}