import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Airplane } from './airplane'; 
var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {

  url = 'https://localhost:44312/api/Airplanes';  
  constructor(private http: HttpClient) { }
  GetAllAirPlane(): Observable<Airplane[]> {  
    return this.http.get<Airplane[]>(this.url);  
  }  
}
