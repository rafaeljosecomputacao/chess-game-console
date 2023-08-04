namespace ChessGame.BoardLayer
{
    internal class Board
    {
        private Part[,] Parts;
        public int Lines { get; set; }
        public int Columns { get; set; }

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Parts = new Part[lines, columns];
        }
    }
}