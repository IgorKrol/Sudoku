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

        [HttpGet()]
        public ActionResult<SudokuBoardDto> Solution(SudokuBoardDto sbDto)
        {
            var result = new BackTracking().BacktrackingSearch(
                new SudokuBoard(sbDto.Board)
            );
            
            if (result.Failed) return null;

            return Ok(new SudokuBoardDto(result));
        }
    }
}