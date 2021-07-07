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
    this.getBoardFromAPI();
  }

  getBoardFromAPI() {
    this.http.get('https://localhost:5001/api/sudoku/530070000600195000098000060800060003400803001700020006060000280000419005000080079').subscribe(response => {
      this.sBoard = response;
      this.sBoard = this.sBoard.board.split('');
    });
  }

}
