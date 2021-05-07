using Model;

namespace Solution
{
    public class BackTracking
    {
        public static SudokuBoard BacktrackingSearch(SudokuBoard sb)
        {

            return RecursiveBacktracking(sb);
        }

        public static SudokuBoard RecursiveBacktracking(SudokuBoard sb)
        {
            if (sb.Complete())
                return sb;

            var index = sb.GetUnassignedIndex();

            ref int unassignedValue = ref sb.Board[index.Item1, index.Item2];


            for (int i = 1; i <= 9; i++)
            {
                if (sb.Valid(index.Item1, index.Item2, i))
                {
                    unassignedValue = i;
                    var result = RecursiveBacktracking(sb);
                    if (!result.Failed) return result;
                    unassignedValue = 0;
                }
            }
            var fResult = new SudokuBoard();
            fResult.Failed = true;
            return fResult;
        }
    }
}