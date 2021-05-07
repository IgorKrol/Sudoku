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

        /*
            Check if inserting 'value' to [x,y] does still maintains Sudoku validation.
            return false if 'value' breaks validation, true otherwise.
        */
        public bool Valid(int indexX, int indexY, int value)
        {
            if (Board == null) return false;

            if (value == 0) return true;

            // Column Check
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                if (Board[i, indexY] == value && i != indexX) return false;
            }
            // Row Check
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                if (Board[indexX, j] == value && j != indexY) return false;
            }
            // Square Check
            for (int i = 0; i < Board.GetLength(0) / 3; i++)
            {
                for (int j = 0; j < Board.GetLength(1) / 3; j++)
                {
                    if (Board[(indexX / 3) * 3 + i, (indexY / 3) * 3 + j] == value
                        && !(indexX == i && indexY == j)) return false;
                }
            }

            return true;
        }

        /*
            Check if Sudoku is 100% unsolvable
            only possible with uncorrect placement which should be solved on client side.
            return: true if unsolvable, false otherwise.
        */
        public bool Unsolvable()
        {
            for (int value = 9; value < 10; value++)
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        if (!this.Valid(i, j, value)) return true;
                    }
                }
            }

            return false;
        }

        /*
            Check if board is complete without empty spaces.
            There is no need to check validation since only valid candidates can be populated
            return true if complete, false otherwise.
        */
        public bool Complete()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == 0) return false;
                }
            }
            return true;
        }
        /*
            Get first unassigned index in board, unassigned marked with 0.
            return (row,col), if no unassigned return (size+1,size+1)
        */
        public Tuple<int, int> GetUnassignedIndex()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (Board[i, j] == 0)
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return Tuple.Create(Board.GetLength(0), Board.GetLength(0));
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