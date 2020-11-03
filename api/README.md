# ChessEncore
.Net Core Chess Engine

## Objectives

## Notes

### Forsyth-Edwards Notation
A FEN "record" defines a particular game position, all in one text line and using only the ASCII character set. A text file with only FEN data records should have the file extension ".fen".

A FEN record contains six fields. The separator between fields is a space. The fields are:

- Piece placement (from White's perspective). Each rank is described, starting with rank 8 and ending with rank 1; within each rank, the contents of each square are described from file "a" through file "h". Following the Standard Algebraic Notation (SAN), each piece is identified by a single letter taken from the standard English names (pawn = "P", knight = "N", bishop = "B", rook = "R", queen = "Q" and king = "K"). White pieces are designated using upper-case letters ("PNBRQK") while black pieces use lowercase ("pnbrqk"). Empty squares are noted using digits 1 through 8 (the number of empty squares), and "/" separates ranks.
- Active color. "w" means White moves next, "b" means Black moves next.
- Castling availability. If neither side can castle, this is "-". Otherwise, this has one or more letters: "K" (White can castle kingside), "Q" (White can castle queenside), "k" (Black can castle kingside), and/or "q" (Black can castle queenside).
En passant target square in algebraic notation. If there's no en passant target square, this is "-". If a pawn has just made a two-square move, this is the position "behind" the pawn. This is recorded regardless of whether there is a pawn in position to make an en passant capture.[2]
- Halfmove clock: This is the number of halfmoves since the last capture or pawn advance. This is used to determine if a draw can be claimed under the fifty-move rule.
- Fullmove number: The number of the full move. It starts at 1, and is incremented after Black's move.


## Performance
I am aware that good code and performant code are not always the same thing.  With that in mind I have tried to strike a balance between the two for fun and science.

https://web.archive.org/web/20131231000000/http://tech.pro/blog/1293/c-performance-benchmark-mistakes-part-one
https://web.archive.org/web/20131231000000/http://tech.pro/tutorial/1295/c-performance-benchmark-mistakes-part-two
https://web.archive.org/web/20131231000000/http://tech.pro/tutorial/1317/c-performance-benchmark-mistakes-part-three
https://web.archive.org/web/20131231000000/http://tech.pro/tutorial/1433/performance-benchmark-mistakes-part-four

### Switch statements vs if-else
https://www.geeksforgeeks.org/switch-vs-else/

### Benchmarking
To explore performance I have also been trying to workout the best way to accurately benchmark code.
https://jonskeet.uk/csharp/benchmark.html
https://stackoverflow.com/a/1048708/874927


