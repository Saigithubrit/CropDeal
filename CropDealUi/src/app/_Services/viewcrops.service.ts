import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Userid } from '../_Models/userid';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ViewcropsService {
  apiurl = environment.baseUrl+'ViewCrop'


  constructor(private http:HttpClient) {
  }
  ViewCrop(){
    return this.http.get(this.apiurl)
  }
  ViewYourCrop(User:any){
    var id = new Userid();
    id.id=User;
    return this.http.post(this.apiurl,id)
  }
}
