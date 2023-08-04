using ChessGame.BoardLayer.Enums;

namespace ChessGame.BoardLayer
{
    internal class Part
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QuantityMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Part(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            QuantityMoves = 0;
        }
    }
}