using System;
using System.ComponentModel;
using ChessEncore.Engine.Enums;

namespace ChessEncore.Engine.V4
{
    public class Board
    {
        private Colour _turn;
        private string _castling;
        private string _enPassant;
        private byte _halfMoveClock;
        private byte _fullMoveNumber;

        /*
         *          A   B   C   D   E   F   G   H
         *        +--------------------------------+   
         *      8 ¦ 00, 01, 02, 03, 04, 05, 06, 07 ¦ 8 
         *      7 ¦ 08, 09, 10, 11, 12, 13, 14, 15 ¦ 7 
         *   R  6 ¦ 16, 17, 18, 19, 20, 21, 22, 23 ¦ 6 
         *   A  5 ¦ 24, 25, 26, 27, 28, 29, 30, 31 ¦ 5 
         *   N  4 ¦ 32, 33, 34, 35, 36, 37, 38, 39 ¦ 4 
         *   K  3 ¦ 40, 41, 42, 43, 44, 45, 46, 47 ¦ 3 
         *      2 ¦ 48, 49, 50, 51, 52, 53, 54, 55 ¦ 2 
         *      1 ¦ 56, 57, 58, 59, 60, 61, 62, 63 ¦ 1 
         *        +--------------------------------+   
         *          A   B   C   D   E   F   G   H
         *                      File 
         */
        private readonly Square[] _board;

        public Board(string fen)
        {
            _board = Setup(fen);
        }

        private Square[] Setup(string boardString)
        {
            var board = new Square[64];
            for (byte i = 0; i < 64; i++)
            {
                board[i] = new Square();
            }

            var squareIndex = 0;
            var spaceCount = 0;
            foreach (var c in boardString)
            {
                if (spaceCount == FenIndex.Pieces)
                {
                    switch (c)
                    {
                        case 'k':
                            board[squareIndex].Piece = new Piece(PieceType.King, Colour.Black);
                            squareIndex++;
                            break;
                        case 'q':
                            board[squareIndex].Piece = new Piece(PieceType.Queen, Colour.Black);
                            squareIndex++;
                            break;
                        case 'b':
                            board[squareIndex].Piece = new Piece(PieceType.Bishop, Colour.Black);
                            squareIndex++;
                            break;
                        case 'r':
                            board[squareIndex].Piece = new Piece(PieceType.Rook, Colour.Black);
                            squareIndex++;
                            break;
                        case 'n':
                            board[squareIndex].Piece = new Piece(PieceType.Knight, Colour.Black);
                            squareIndex++;
                            break;
                        case 'p':
                            board[squareIndex].Piece = new Piece(PieceType.Pawn, Colour.Black);
                            squareIndex++;
                            break;
                        case 'K':
                            board[squareIndex].Piece = new Piece(PieceType.King, Colour.White);
                            squareIndex++;
                            break;
                        case 'Q':
                            board[squareIndex].Piece = new Piece(PieceType.Queen, Colour.White);
                            squareIndex++;
                            break;
                        case 'B':
                            board[squareIndex].Piece = new Piece(PieceType.Bishop, Colour.White);
                            squareIndex++;
                            break;
                        case 'R':
                            board[squareIndex].Piece = new Piece(PieceType.Rook, Colour.White);
                            squareIndex++;
                            break;
                        case 'N':
                            board[squareIndex].Piece = new Piece(PieceType.Knight, Colour.White);
                            squareIndex++;
                            break;
                        case 'P':
                            board[squareIndex].Piece = new Piece(PieceType.Pawn, Colour.White);
                            squareIndex++;
                            break;
                        case '1':
                            squareIndex += 1;
                            break;
                        case '2':
                            squareIndex += 2;
                            break;
                        case '3':
                            squareIndex += 3;
                            break;
                        case '4':
                            squareIndex += 4;
                            break;
                        case '5':
                            squareIndex += 5;
                            break;
                        case '6':
                            squareIndex += 6;
                            break;
                        case '7':
                            squareIndex += 7;
                            break;
                        case '8':
                            squareIndex += 8;
                            break;
                        case ' ':
                            spaceCount++;
                            break;
                    }
                }
                else if (c == ' ')
                {
                    spaceCount++;
                }
                else if (spaceCount == FenIndex.PlayerTurn)
                {
                    _turn = c == 'w' ? Colour.White : Colour.Black;
                }
                else if (spaceCount == FenIndex.Castling)
                {
                    // TODO not the correct implementation
                    _castling += c;
                }
                else if (spaceCount == FenIndex.EnPassant)
                {
                    // TODO not the correct implementation
                    _enPassant += c;
                }
                else if (spaceCount == FenIndex.HalfMoveClock)
                {
                    _halfMoveClock = MultiplyByTenAndAddCharValue(c, _halfMoveClock);
                }
                else if (spaceCount == FenIndex.FullMoveClock)
                {
                    _fullMoveNumber = MultiplyByTenAndAddCharValue(c, _fullMoveNumber);
                }
            }

            return board;
        }

        public string Fen()
        {
            var fen = "";

            var blankCount = 0;
            for (var i = 0; i < 64; i++)
            {
                if (i > 0 && i % 8 == 0)
                {
                    if (blankCount > 0)
                    {
                        fen += blankCount;
                        blankCount = 0;
                    }
                    fen += "/";
                }

                var piece = _board[i].Piece;
                if (piece == null)
                {
                    blankCount++;
                    continue;
                }

                if (blankCount > 0)
                {
                    fen += blankCount;
                }

                fen += ToFenRepresentation(piece.Type, piece.Colour);
                blankCount = 0;
            }

            fen += $" {(_turn == Colour.White ? "w" : "b")}";
            fen += $" {_castling} {_enPassant} {_halfMoveClock} {_fullMoveNumber}";

            return fen;
        }

        private static byte MultiplyByTenAndAddCharValue(char character, byte originalValue)
        {
            return character switch
            {
                '0' => originalValue,
                '1' => (byte)((originalValue * 10) + 1),
                '2' => (byte)((originalValue * 10) + 2),
                '3' => (byte)((originalValue * 10) + 3),
                '4' => (byte)((originalValue * 10) + 4),
                '5' => (byte)((originalValue * 10) + 5),
                '6' => (byte)((originalValue * 10) + 6),
                '7' => (byte)((originalValue * 10) + 7),
                '8' => (byte)((originalValue * 10) + 8),
                '9' => (byte)((originalValue * 10) + 9),
                _ => throw new InvalidEnumArgumentException("Clock don't work this way dammit'")
            };
        }
        
        private static string ToFenRepresentation(PieceType pieceType, Colour colour)
        {
            var pieceString = pieceType switch
            {
                PieceType.King => "k",
                PieceType.Queen => "q",
                PieceType.Bishop => "b",
                PieceType.Rook => "r",
                PieceType.Knight => "n",
                PieceType.Pawn => "p",
                _ => throw new InvalidOperationException("Invalid character piece provided")
            };

            return colour == Colour.White ? pieceString.ToUpper() : pieceString;
        }
    }
}
