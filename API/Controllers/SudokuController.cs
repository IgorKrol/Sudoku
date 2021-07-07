using System;
using System.Collections.Generic;
using System.Linq;
using API.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;
using Solution;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SudokuController : ControllerBase
    {
        public SudokuController()
        {

        }

        // GET /api/sudoku/{boardString}
        // returns sudoku solution

        [HttpGet("{boardString}")]
        public ActionResult<SudokuBoardDto> Solution(string boardString)
        {
            var result = new BackTracking()
                .BacktrackingSearch(new SudokuBoard(boardString));
            
            var sbDto = new SudokuBoardDto(result);

            if (result.Failed){
                sbDto.Board = "failed";
            }

            return Ok(sbDto);
        }
    }
}