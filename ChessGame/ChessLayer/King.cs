using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class King : Part
    {
        public King(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }
    }
}