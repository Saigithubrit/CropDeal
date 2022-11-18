import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable,Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private inject:Injector) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let accounservice = this.inject.get(AccountService);
    let jwtToken=req.clone({
      setHeaders:{
        Authorization: 'bearer '+accounservice.GetToken()
      }
    });
    return next.handle(jwtToken);
  }
  

}
