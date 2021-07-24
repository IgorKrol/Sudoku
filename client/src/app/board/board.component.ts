import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-board',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  doc = document;
  sBoard: any;
  Counter = 0;

  constructor(private http: HttpClient) {

  }

  ngOnInit(): void {
    var temp = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
    this.sBoard = temp.split('');
  }

  //reset board to 0 or no-value
  resetBoard() {
    for (let i = 0; i < this.sBoard.length; i++) {
      this.sBoard[i]='0';
      (<HTMLInputElement>this.doc.getElementById('t'+i)).value = '';
    }    
  }

  //return readonly value
  getValue(id:string){
    return (<HTMLInputElement>this.doc.getElementById(id))?.value;
  }

  //convert board from string[] to String
  boardToString(): string {
    let res = '';
    for (let i = 0; i < this.sBoard.length; i++) {
      let tileValue = this.getValue('t'+i); 
      res += tileValue == '' ? '0' : tileValue;
    }
    console.log(res);
    
    return res;
  }


  //send board for solving 
  solve() {
    this.http.get('https://localhost:5001/api/sudoku/' + this.boardToString()).subscribe(response => {
      this.sBoard = response;
      this.sBoard = this.sBoard.board.split('');
    })

  }

  //convert single zero on board to empty space
  convertZeroToEmpty(s: string) {
    if (s.includes('0'))
      return '';
    return s;
  }


  //STYLE

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
  isLeft(i: number) {
    if (i % 3 == 0)
      return true;
    return false;
  }
}
