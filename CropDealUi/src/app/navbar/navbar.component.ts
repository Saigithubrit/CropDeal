import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  Isloggedin:any;
  user:any;

  constructor() { }

  ngOnInit(): void {

   this.checkstorage();
    
  }
  checkstorage(){
    this.user =localStorage.getItem('token');
    if(this.user!=null){
      this.Isloggedin =true;
    }
  }  
 
    
  
  logout(){
    localStorage.clear();
    this.Isloggedin=false;
  }

  
}
