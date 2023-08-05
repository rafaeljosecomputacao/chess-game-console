using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class Tower : Part
    {
        public Tower(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
        }
    }
}