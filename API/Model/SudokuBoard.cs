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

        public SudokuBoard(string board)
        {
            int[] tempBoard = new int[81];
            for (int i = 0; i < tempBoard.Length; i++)
            {
                tempBoard[i] = int.Parse(board[i].ToString());
            }
            initBoard(tempBoard);
            Failed = false;

        }
        public SudokuBoard(int[] board)
        {
            initBoard(board);
        }


        // init this.Board with 1D array
        private void initBoard(int[] board)
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