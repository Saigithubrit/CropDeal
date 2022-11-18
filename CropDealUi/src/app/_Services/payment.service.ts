import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  apiurl = environment.baseUrl+'Payment/'
  

  constructor(private http:HttpClient) { }

  payment(payment:any){
    return this.http.post(this.apiurl,payment)
  }
  invoice(userid:any){
    return this.http.get(this.apiurl+'DealerInvoice?UserId='+userid);
  }

  Farmerinvoice(userid:any){
    return this.http.get(this.apiurl+'FarmerInvoice?UserId='+userid);
  }


}
