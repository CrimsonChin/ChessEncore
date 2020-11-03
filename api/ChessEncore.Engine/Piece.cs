using ChessEncore.Engine.Enums;

namespace ChessEncore.Engine
{
    internal class Piece
    {
        public Piece(PieceType type, Colour colour)
        {
            Type = type;
            Colour = colour;
        }

        public PieceType Type { get; }

        public Colour Colour { get; }
    }
}
