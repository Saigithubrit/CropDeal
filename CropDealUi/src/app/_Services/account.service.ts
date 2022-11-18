import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
apiurl = environment.baseUrl+'Login/'
  constructor(private http:HttpClient) { }

  proceedLogin(usercred:any){
    return this.http.post(this.apiurl+"login",usercred)
    
  }
  GetToken(){
    return localStorage.getItem('token')||''
  }

  

}
