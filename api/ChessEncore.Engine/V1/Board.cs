using System.Collections.Generic;
using System.Linq;

namespace ChessEncore.Engine.V1
{
    public class Board
    {
        private List<List<Piece>> _board;

        public Board(string fen)
        {
            _board = Setup(fen);
        }

        private List<List<Piece>> Setup(string boardString)
        {
            var board = new List<List<Piece>>(8);

            board.AddRange(boardString.Split("/").Select(PopulateRow));

            return board;
        }

        private static List<Piece> PopulateRow(string fenRow)
        {
            var row = new List<Piece>(8);

            foreach (var character in fenRow)
            {
                if (int.TryParse(character.ToString(), out var emptyCount))
                {
                    row.AddRange(new Piece[emptyCount]);
                    break;
                }

                row.Add(new Piece(character.ToString()));
            }

            return row;
        }

        public string Fen()
        {
            var fen = "";

            for (var rowIndex = 0; rowIndex < _board.Count; rowIndex++)
            {
                if (rowIndex > 0)
                {
                    fen += "/";
                }

                var blankCount = 0;
                foreach (var piece in _board[rowIndex])
                {
                    if (piece == null)
                    {
                        blankCount++;
                        continue;
                    }

                    if (blankCount > 0)
                    {
                        fen += blankCount;
                    }

                    fen += piece.Name;
                    blankCount = 0;
                }

                if (blankCount > 0)
                {
                    fen += blankCount;
                }
            }

            return fen;
        }
    }
}
