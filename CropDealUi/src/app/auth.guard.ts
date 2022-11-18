import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { elementAt, Observable } from 'rxjs';
import { RegisterService } from './_Services/register.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private regservice: RegisterService, private router:Router )
  {

  }
  canActivate(): boolean{
    if(this.regservice.loggedIn()){
      return true
    }else{
      this.router.navigate(['/Login'])
      return false
    }
    
  }
}
