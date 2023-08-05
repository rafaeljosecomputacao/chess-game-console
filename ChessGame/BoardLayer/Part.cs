using ChessGame.BoardLayer.Enums;

namespace ChessGame.BoardLayer
{
    internal class Part
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QuantityMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Part(Board board, Color color)
        {
            Board = board;
            Color = color;
            Position = null;        
            QuantityMoves = 0;
        }

        public void IncreaseQuantityMoves()
        {
            QuantityMoves++;
        }
    }
}