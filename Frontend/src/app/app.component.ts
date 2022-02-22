import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import {Chart, ChartItem} from 'chart.js';
import { FormBuilder } from '@angular/forms';
import { observable, Observable } from 'rxjs';
import { observeNotification } from 'rxjs/internal/Notification';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  @Input() chart: any;
  @Input() id: any;
  title = 'rssfeed';
  word: string = "";
  chartData: any[] = [];
  scuffedForm = this.formBuilder.group({
    tag: ' '
  })
  myChart :any
   

  constructor(private http: HttpClient, private formBuilder:FormBuilder){}

  ngOnInit(){

    
    this.myChart = new Chart(<HTMLCanvasElement> document.getElementById("myChart"), {

      type: 'line',
      data:{
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul','Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
        datasets: [{
          label: 'Word Count for ' + this.word,
          data: this.chartData,
          backgroundColor: 'lightgreen',
          borderColor: 'blue',
          borderWidth: 1
      }]
  
  
      }
  
  
    });

  }

  ngAfterViewInit(){

    


  }

  addChart(){

    this.myChart = new Chart(<HTMLCanvasElement> document.getElementById("myChart"), {

      type: 'line',
      data:{
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul','Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
        datasets: [{
          label: 'Word Count for ' + this.word,
          data: this.chartData,
          backgroundColor: 'lightgreen',
          borderColor: 'blue',
          borderWidth: 1
      }]
  
  
      }
  
  
    });


  }

  getChartValues(){
    
    var searchString = this.scuffedForm.controls['tag'];
    
    this.http.post<any>('https://localhost:7220/api/GetTrendValues', {'word': searchString.value }).subscribe(data => {
      this.chartData = data.counts;
      this.word = data.word;
      this.myChart.destroy();
      this.addChart();
      console.log("After request: ", this.chartData);
      
    })


    


  }


}


