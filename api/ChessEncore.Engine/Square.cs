namespace ChessEncore.Engine
{
    internal class Square
    {
        public Square()
        {
        }

        public Square(Piece piece)
        {
            Piece = piece;
        }

        public Piece Piece { get; set; }
    }
}
