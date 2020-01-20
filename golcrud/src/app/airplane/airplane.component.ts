import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { AirplaneService } from '../airplane.service';  
import { Airplane } from '../airplane';  
@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styleUrls: ['./airplane.component.css']
})
export class AirplaneComponent implements OnInit {
  dataSaved = false;  
  allAirplane: Observable<Airplane[]>; 
  message = null;  
  constructor(private formbulider: FormBuilder, private airplaneService:AirplaneService) { }
  ngOnInit() {
  
    this.loadAllAirPlane();  
  }
  loadAllAirPlane() {  
    this.allAirplane = this.airplaneService.GetAllAirPlane();  
  } 
   
}