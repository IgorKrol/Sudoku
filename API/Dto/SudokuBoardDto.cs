using System;
using Model;

namespace API.Dto
{
    public class SudokuBoardDto
    {
        public int[] Board { get; set; }
        public bool Failed { get; set; }

        public SudokuBoardDto(SudokuBoard sb)
        {
            Board = new int[sb.Board.Length];

            int sqrLength = (int)Math.Sqrt(sb.Board.Length);

            for (int i = 0; i < Board.Length; i++)
            {
                Board[i] = sb.Board[i / sqrLength, i % sqrLength];
            }
            Failed = sb.Failed;
        }
    }
}