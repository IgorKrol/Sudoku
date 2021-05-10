using System;

namespace Model
{
    public class SudokuBoard
    {
        public int[,] Board { get; set; } = new int[9, 9]{
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9},
            {9,9,9,9,9,9,9,9,9}
        };
        public bool Failed { get; set; } = false;

        public SudokuBoard()
        {
        }

        public SudokuBoard(int[,] board)
        {
            this.Board = board;
        }
        public SudokuBoard(int[] board)
        {
            int sqrLength = (int)Math.Sqrt(Board.Length);

            for (int i = 0; i < Board.Length; i++)
            {
                Board[i / sqrLength, i % sqrLength] = board[i];
            }
        }

        public string toString()
        {
            string result = "";

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                result += i % 3 == 0 ? "-------------------\n" : "";
                // result += "|";
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    result += j % 3 == 0 ? "|" : ",";
                    result += Board[i, j];
                }
                // result += Board[i, Board.GetLength(0) - 1] + "|\n";
                result += "|\n";
            }

            return result + "-------------------";
        }
    }
}