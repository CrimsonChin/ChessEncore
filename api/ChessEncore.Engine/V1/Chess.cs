using System;
using System.Collections.Generic;
using ChessEncore.Engine.Enums;

namespace ChessEncore.Engine.V1
{
    public class Chess
    {
        private Board _board;
        private Colour _turn;
        private string _castling;
        private string _enPassant;
        private int _halfMoveClock;
        private int _fullMoveNumber;

        public Chess(string fen)
        {
            Setup(fen);
        }

        private void Setup(string fen)
        {
            var fenRecordItems = fen.Split(" ");

            if (fenRecordItems.Length != 6)
            {
                throw new InvalidOperationException("Incorrectly formatted FEN string provided.");
            }

            _board = new Board(fenRecordItems[FenIndex.Pieces]);
            SetupTrackers(fenRecordItems);
        }

        private void SetupTrackers(IReadOnlyList<string> fenRecordItems)
        {
            _turn = fenRecordItems[FenIndex.PlayerTurn] == "w" ? Colour.White : Colour.Black;
            _castling = fenRecordItems[FenIndex.Castling];
            _enPassant = fenRecordItems[FenIndex.EnPassant];

            int.TryParse(fenRecordItems[FenIndex.HalfMoveClock], out _halfMoveClock);
            int.TryParse(fenRecordItems[FenIndex.FullMoveClock], out _fullMoveNumber);
        }

        public string Fen()
        {
            var fen = _board.Fen();

            fen += $" {(_turn == Colour.White ? "w" : "b")}";
            fen += $" { _castling } { _enPassant } { _halfMoveClock} { _fullMoveNumber}";

            return fen;
        }
    }
}
