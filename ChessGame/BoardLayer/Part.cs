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

        public void DecrementQuantityMoves()
        {
            QuantityMoves--;
        }     

        public bool ExistPossibleMoves()
        {
            bool[,] matrix = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}