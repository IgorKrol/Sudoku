using System;
using Model;

namespace Solution
{
    public class BackTracking
    {
        private SudokuBoard sudokuBoard;
        // always symetric
        private int length;

        public SudokuBoard BacktrackingSearch(SudokuBoard sb)
        {
            this.sudokuBoard = sb;
            this.length = sb.Board.GetLength(0);
            return RecursiveBacktracking();
        }

        private SudokuBoard RecursiveBacktracking()
        {
            if (Complete())
                return sudokuBoard;

            var index = GetUnassignedIndex();

            ref int unassignedValue = ref sudokuBoard.Board[index.Item1, index.Item2];


            for (int i = 1; i <= 9; i++)
            {
                if (Valid(index.Item1, index.Item2, i))
                {
                    unassignedValue = i;
                    var result = RecursiveBacktracking();
                    if (!result.Failed) return result;
                    unassignedValue = 0;
                }
            }
            var fResult = new SudokuBoard();
            fResult.Failed = true;
            return fResult;
        }


        /*
            Check if inserting 'value' to [x,y] does still maintains Sudoku validation.
            return false if 'value' breaks validation, true otherwise.
        */
        public bool Valid(int indexX, int indexY, int value)
        {
            if (sudokuBoard.Board == null) return false;

            if (value == 0) return true;

            // Column Check
            for (int i = 0; i < length; i++)
            {
                if (sudokuBoard.Board[i, indexY] == value && i != indexX) return false;
            }
            // Row Check
            for (int j = 0; j < length; j++)
            {
                if (sudokuBoard.Board[indexX, j] == value && j != indexY) return false;
            }
            // Square Check
            for (int i = 0; i < length / 3; i++)
            {
                for (int j = 0; j < length / 3; j++)
                {
                    if (sudokuBoard.Board[(indexX / 3) * 3 + i, (indexY / 3) * 3 + j] == value
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
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
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
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (sudokuBoard.Board[i, j] == 0) return false;
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
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (sudokuBoard.Board[i, j] == 0)
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return Tuple.Create(length,length);
        }
    }
}