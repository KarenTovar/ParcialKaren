import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Services/api.service';

@Component({
  selector: 'app-farmacia',
  templateUrl: './farmacia.component.html',
  styleUrls: ['./farmacia.component.css']
})
export class FarmaciaComponent implements OnInit{
  constructor(public api:ApiService){} 
  ngOnInit(): void {
    var response=this.api.getAll("Farmaciums")
    console.log(response);
  }
}
