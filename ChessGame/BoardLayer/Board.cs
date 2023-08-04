using ChessGame.BoardLayer.Exceptions;

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

        public Part Part(int lines, int columns) 
        { 
            return Parts[lines, columns];
        }

        public Part Part(Position position)
        {
            return Parts[position.Line, position.Column];
        }

        public bool ExistPart(Position position)
        {
            ValidatePosition(position);
            return Part(position) != null;
        }

        public void PutPart(Part part, Position position)
        {
            if (ExistPart(position))
            {
                throw new BoardException("There is already a part in this position");
            }
            Parts[position.Line, position.Column] = part;
            part.Position = position;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position");
            }
        }
    }
}