//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.VisualBasic;

//namespace ChessEncore.Engine.Bitboard
//{
//    class Class1
//    {
//        internal UInt64 WhiteKing;
//        internal UInt64 WhiteQueens;
//        internal UInt64 WhiteRooks;
//        internal UInt64 WhiteBishops;
//        internal UInt64 WhiteKnights;
//        internal UInt64 WhitePawns;
//        internal UInt64 WhitePieces;

//        // Initialise piece bitboards using square contents.
//        private void InitPieceBitboards()
//        {
//            WhiteKing = 0;
//            WhiteQueens = 0;
//            WhiteRooks = 0;
//            WhiteBishops = 0;
//            WhiteKnights = 0;
//            WhitePawns = 0;

//            for (Int16 i = 0; i < 64; i++)
//            {
//                if (this.Squares[i] == 'K') 
//                {
//                    this.WhiteKing = this.WhiteKing | Constants.BITSET[i];
//                }

//                if (this.Squares[i] == Constants.WHITE_QUEEN)
//                {
//                    this.WhiteQueens = this.WhiteQueens | Constants.BITSET[i];
//                }

//                if (this.Squares[i] == Constants.WHITE_ROOK)
//                {
//                    this.WhiteRooks = this.WhiteRooks | Constants.BITSET[i];
//                }

//                if (this.Squares[i] == Constants.WHITE_BISHOP)
//                {
//                    this.WhiteBishops = this.WhiteBishops | Constants.BITSET[i];
//                }

//                if (this.Squares[i] == Constants.WHITE_KNIGHT)
//                {
//                    this.WhiteKnights = this.WhiteKnights | Constants.BITSET[i];
//                }

//                if (this.Squares[i] == Constants.WHITE_PAWN)
//                {
//                    this.WhitePawns = this.WhitePawns | Constants.BITSET[i];
//                }

//                this.WhitePieces = this.WhiteKing | this.WhiteQueens |
//                                   this.WhiteRooks | this.WhiteBishops |
//                                   this.WhiteKnights | this.WhitePawns;
//                //this.BlackPieces = this.BlackKing | this.BlackQueens |
//                //                   this.BlackRooks | this.BlackBishops |
//                //                   this.BlackKnights | this.BlackPawns;
//                //this.SquaresOccupied = this.WhitePieces | this.BlackPieces;
//            }
//        }

//        public char[] Squares { get; set; }
//    }
//}
