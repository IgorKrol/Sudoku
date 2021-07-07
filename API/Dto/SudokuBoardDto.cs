using System;
using Model;

namespace API.Dto
{
    public class SudokuBoardDto
    {
        public string Board { get; set; } = "";
        
        public SudokuBoardDto(SudokuBoard sb)
        {
            foreach(int i in sb.Board){
                this.Board+=i;
            }
        }
    }
}