using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessEncore.Engine;
using ChessEncore.Engine.V1;
using Board = ChessEncore.Engine.V2.Board;

namespace ChessEncore
{
    class Program
    {
        static void Main(string[] args)
        {
            //var newGameFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

            //Console.WriteLine("V1");
            //var chess = new Chess(newGameFen);
            //Console.WriteLine(chess.Fen());
            
            //Console.WriteLine("V2");
            //var boardV2 = new Board(newGameFen);
            //Console.WriteLine(boardV2.Fen());

            //Console.WriteLine("V3");
            //var boardV3 = new Engine.V3.Board(newGameFen);
            //Console.WriteLine(boardV3.Fen());

            //Console.WriteLine("V4");
            //var boardV4 = new Engine.V4.Board(newGameFen);
            //Console.WriteLine(boardV4.Fen());

            Console.WriteLine(70);
            Console.WriteLine(70);

            var b = new List<bool>();
            for (int i = 1; i < 64; i++)
            {
                b.Add(false);
            }
            b.Add(true);
            var board = new BitArray(b.ToArray());


            UInt64 a = BitArrayToU64(board);
            Console.WriteLine(a);
            Console.WriteLine(ToBitString(board));

            //var byteArray = new byte[] { 0,0,0,0,0,0,0,1 };
            //var bitArray = new BitArray(byteArray);
            //Console.Write(Convert.ToInt16(bitArray));
            //a = BitArrayToU64(board);
            //Console.WriteLine(a);
            //Console.WriteLine(ToBitString(board));


            BitArray bob = new BitArray(new byte[] { 3 });
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();

            Console.Write(ToBitString(bob));
            
            
            
            Console.ReadKey();

            //var play = true;
            //while (play)
            //{
            //    Console.WriteLine("What would you like to do?");
            //    var input = Console.ReadLine();
            //    if (input == "q")
            //    {
            //        play = false;
            //    }


            //}

            //Console.WriteLine("You killed jester.  Your quest is over.");
        }

        //public string Bye(int x)
        //{
        //    string s = Convert.ToString(x, 2); //Convert to binary in a string

        //    int[] bits = s.PadLeft(8, '0') // Add 0's from left
        //        .Select(c => int.Parse(c.ToString())) // convert each char to int
        //        .ToArray(); // Convert IEnumerable from select to Array

        //    return bits;
        //}

        public int[] Hello(int x)
        {
            BitArray b = new BitArray(new[] { x });
            int[] bits = b.Cast<bool>().Select(bit => bit ? 1 : 0).ToArray();

            return bits;
        }

        public static string ToBitString(BitArray bits)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < bits.Count; i++)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static ulong BitArrayToU64(BitArray ba)
        {
            var len = Math.Min(64, ba.Count);
            ulong n = 0;
            for (int i = 0; i < len; i++)
            {
                if (ba.Get(i))
                    n |= 1UL << i;
            }
            return n;
        }
    }
}
