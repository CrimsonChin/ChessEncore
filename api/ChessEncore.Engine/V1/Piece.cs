using ChessEncore.Engine.Enums;

namespace ChessEncore.Engine.V1
{
    internal class Piece
    {
        public Piece(string pieceCharacter)
        {
            Name = pieceCharacter;
            Colour = (pieceCharacter == pieceCharacter.ToUpper()) ? Colour.White : Colour.Black;
        }

        public string Name { get; }

        public Colour Colour { get; }
    }
}
