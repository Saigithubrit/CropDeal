import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-features',
  templateUrl: './features.component.html',
  styleUrls: ['./features.component.css']
})
export class FeaturesComponent implements OnInit {

  constructor(private route:Router) { }
  role:any;

  ngOnInit(): void {
    this.feature()
  }
  feature(){
   this.role = localStorage.getItem('role');
   console.log(this.role);
   if( this.role == '"Admin"'){
    this.route.navigate(['/Adminlanding']);

   }
   if(this.role == '"Dealer"'){
    this.route.navigate(['/Dealerlanding']);

   }if( this.role == '"Farmer"')
    this.route.navigate(['/Farmerlanding']);
  }

  }


