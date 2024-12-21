import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../header/header/header.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClient } from '@angular/common/http'; 
import { AgGridModule } from 'ag-grid-angular';

interface Todo {
  TaskId: number;
  UserId: number;
  Name: string;
  TaskTitle: string;
  Completed: boolean;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderComponent, CommonModule, HttpClientModule, AgGridModule],  
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public rowData: any[] = [];  
  public columnDefs = [
    { field: 'TaskId',sortable: true, filter: true },
    { field: 'UserId',sortable: true, filter: true },
    { field: 'Name',sortable: true, filter: true},
    { field: 'TaskTitle',sortable: true, filter: true , width: 450},
    { field: 'Completed',sortable: true, filter: true }
  ];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get<Todo[]>('https://localhost:44384/api/Todo')
      .subscribe(data => {
        this.rowData = data;
      });
  }
}
