import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-board',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  sBoard: any;
  Counter = 0;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    var temp = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
    this.sBoard = temp.split('');
  }

  // nothing for now.
  // getBoardFromAPI() {
  //   this.http.get('https://localhost:5001/api/sudoku/530070000600195000098000060800060003400803001700020006060000280000419005000080079').subscribe(response => {
  //     this.sBoard = response;
  //     this.sBoard = this.sBoard.board.split('');
  //   });
  // }


  //convert board from string[] to String
  boardToString(): string{
    let res = '';
    for(let s in this.sBoard){
      res += s==' '? '0' : s;
    }
    return res;
  }


  //send board for solving 
  solve(){
    this.http.get('https://localhost:5001/api/sudoku/'+ this.boardToString()).subscribe(response => {
      this.sBoard = response;
      this.sBoard = this.sBoard.board.split('');
    })
  }

  //convert single zero on board to empty space
  convertZeroToEmpty(s: string) {
    if (s.includes('0'))
      return ' ';
    return s;
  }

  // method for selecting rough border - style
  isTop(i: number): boolean {
    if (
      Number(i) >= 27 && Number(i) <= 35 ||
      Number(i) >= 54 && Number(i) <= 62
    )
      return true;
    return false;
  }

  // method for selecting rough border - style
  isLeft(i: number){
    if (i%3==0)
      return true;
    return false;
  }
}
