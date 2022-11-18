import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class CropsService {

  apiurl = environment.baseUrl+'Crops/'

  constructor(private http:HttpClient) { }

  getcrops(){
    return this.http.get(this.apiurl);
  }
}
