using System;
using System.IO;
using Model;
using Solution;

namespace LocalTests
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string resultString = "";

            int[,] sudokuText = new int[9, 9]{
                {5,3,0,0,7,0,0,0,0},
                {6,0,0,1,9,5,0,0,0},
                {0,9,8,0,0,0,0,6,0},
                {8,0,0,0,6,0,0,0,3},
                {4,0,0,8,0,3,0,0,1},
                {7,0,0,0,2,0,0,0,6},
                {0,6,0,0,0,0,2,8,0},
                {0,0,0,4,1,9,0,0,5},
                {0,0,0,0,8,0,0,7,9}
            };

            int[,] sudokuTextUnsolvable = new int[9, 9]{
                {5,3,2,0,7,0,0,0,0},
                {6,0,0,1,9,5,0,0,0},
                {0,9,8,0,0,0,0,6,0},
                {8,0,0,0,6,0,0,0,3},
                {4,0,0,8,0,3,0,0,1},
                {7,0,0,0,2,0,0,0,6},
                {0,6,0,0,0,0,2,8,0},
                {0,0,0,4,1,9,0,0,5},
                {0,0,0,0,8,0,0,7,9}
            };

            SudokuBoard bTest = new SudokuBoard(sudokuText);
            resultString += "## TEST 1 - Solvable\n";
            resultString += bTest.toString() + "\n";

            // System.Console.WriteLine(bTest.toString());

            var result = BackTracking.BacktrackingSearch(bTest);
            resultString += "## RESULT 1\n";

            resultString += result.toString() + "\n";

            // System.Console.WriteLine(result.toString());
            SudokuBoard buTest = new SudokuBoard(sudokuTextUnsolvable);
            resultString += "## TEST 2 - Unsolvable\n";

            resultString += buTest.toString() + "\n";

            // System.Console.WriteLine(bTest.toString());

            result = BackTracking.BacktrackingSearch(buTest);
            resultString += "## RESULT 2\n";

            resultString += result.toString() + "\n";

            await File.WriteAllTextAsync("Result.txt", resultString);

            System.Console.WriteLine(resultString);
            // System.Console.WriteLine(result.toString());
        }
    }
}
