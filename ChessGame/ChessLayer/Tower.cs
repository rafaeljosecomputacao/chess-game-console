using ChessGame.BoardLayer;
using ChessGame.BoardLayer.Enums;

namespace ChessGame.ChessLayer
{
    internal class Tower : Part
    {
        public Tower(Color color, Board board) : base(color, board) { }

        public override string ToString()
        {
            return "T";
        }
    }
}