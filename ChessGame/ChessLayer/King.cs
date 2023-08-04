using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class King : Part
    {
        public King(Color color, Board board) : base(color, board) { }

        public override string ToString()
        {
            return "K";
        }
    }
}