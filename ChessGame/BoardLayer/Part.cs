using ChessGame.BoardLayer.Enums;

namespace ChessGame.BoardLayer
{
    internal abstract class Part
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QuantityMoves { get; protected set; }
        public Board Board { get; protected set; }

        public Part(Board board, Color color)
        {
            Position = null;         
            Color = color;
            QuantityMoves = 0;
            Board = board;
        }

        public void IncreaseQuantityMoves()
        {
            QuantityMoves++;
        }

        public abstract bool[,] PossibleMoves();
    }
}