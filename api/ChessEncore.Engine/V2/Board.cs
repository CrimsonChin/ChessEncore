using System;
using System.ComponentModel;
using ChessEncore.Engine.Enums;

namespace ChessEncore.Engine.V2
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
                    if (c == 'k')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.King, Colour.Black);
                        squareIndex++;
                    }
                    else if (c == 'q')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Queen, Colour.Black);
                        squareIndex++;
                    }
                    else if (c == 'b')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Bishop, Colour.Black);
                        squareIndex++;
                    }
                    else if (c == 'r')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Rook, Colour.Black);
                        squareIndex++;
                    }
                    else if (c == 'n')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Knight, Colour.Black);
                        squareIndex++;
                    }
                    else if (c == 'p')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Pawn, Colour.Black);
                        squareIndex++;
                    }
                    else if (c == 'K')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.King, Colour.White);
                        squareIndex++;
                    }
                    else if (c == 'Q')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Queen, Colour.White);
                        squareIndex++;
                    }
                    else if (c == 'B')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Bishop, Colour.White);
                        squareIndex++;
                    }
                    else if (c == 'R')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Rook, Colour.White);
                        squareIndex++;
                    }
                    else if (c == 'N')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Knight, Colour.White);
                        squareIndex++;
                    }
                    else if (c == 'P')
                    {
                        board[squareIndex].Piece = new Piece(PieceType.Pawn, Colour.White);
                        squareIndex++;
                    }
                    else if (c == '1')
                    {
                        squareIndex += 1;
                    }
                    else if (c == '2')
                    {
                        squareIndex += 2;
                    }
                    else if (c == '3')
                    {
                        squareIndex += 3;
                    }
                    else if (c == '4')
                    {
                        squareIndex += 4;
                    }
                    else if (c == '5')
                    {
                        squareIndex += 5;
                    }
                    else if (c == '6')
                    {
                        squareIndex += 6;
                    }
                    else if (c == '7')
                    {
                        squareIndex += 7;
                    }
                    else if (c == '8')
                    {
                        squareIndex += 8;
                    }
                    else if (c == ' ')
                    {
                        spaceCount++;
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
                    if (c == '0')
                    {

                    }
                    else if (c == '1')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 1);
                    }
                    else if (c == '2')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 2);
                    }
                    else if (c == '3')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 3);
                    }
                    else if (c == '4')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 4);
                    }
                    else if (c == '5')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 5);
                    }
                    else if (c == '6')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 6);
                    }
                    else if (c == '7')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 7);
                    }
                    else if (c == '8')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 8);
                    }
                    else if (c == '9')
                    {
                        _halfMoveClock = (byte)((_halfMoveClock * 10) + 9);
                    }
                }
                else if (spaceCount == FenIndex.FullMoveClock)
                {
                    if (c == '0')
                    {

                    }
                    else if (c == '1')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 1);
                    }
                    else if (c == '2')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 2);
                    }
                    else if (c == '3')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 3);
                    }
                    else if (c == '4')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 4);
                    }
                    else if (c == '5')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 5);
                    }
                    else if (c == '6')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 6);
                    }
                    else if (c == '7')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 7);
                    }
                    else if (c == '8')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 8);
                    }
                    else if (c == '9')
                    {
                        _fullMoveNumber = (byte)((_fullMoveNumber * 10) + 9);
                    }
                }
            }

            return board;
        }

        private static byte MultiplyByTenAndAddChar(char character, byte originalValue)
        {
            return character switch
            {
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
        
        private static string ToFenRepresentation(PieceType pieceType, Colour colour)
        {
            var pieceString = pieceType switch
            {
                PieceType.King => "k",
                PieceType.Queen => "q",
                PieceType.Bishop => "b",
                PieceType.Rook => "r",
                PieceType.Knight => "c",
                PieceType.Pawn => "p",
                _ => throw new InvalidOperationException("Invalid character piece provided")
            };

            return colour == Colour.White ? pieceString.ToUpper() : pieceString;
        }
    }
}
