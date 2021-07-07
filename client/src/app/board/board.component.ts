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
    this.http.get('https://localhost:5001/api/sudoku').subscribe(response => {
      this.sBoard = response;
    });
  }

}
