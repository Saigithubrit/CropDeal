import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ChangestatusService {
  apiurl = environment.baseUrl+'User/'

  constructor(private http:HttpClient) { }

  changeStatus(userstatus:any){
    return this.http.post(this.apiurl,userstatus);
  }
}
