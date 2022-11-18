import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class CropsonsaleService {
  apiurl = environment.baseUrl+'CropOnSales/'

  constructor(private http:HttpClient) { }

  croponsale(cropad:any){
    return this.http.post(this.apiurl,cropad)
  }

}
