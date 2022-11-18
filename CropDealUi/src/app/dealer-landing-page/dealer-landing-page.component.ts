import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dealer-landing-page',
  templateUrl: './dealer-landing-page.component.html',
  styleUrls: ['./dealer-landing-page.component.css']
})
export class DealerLandingPageComponent implements OnInit {

  constructor() {
  
   }

  ngOnInit(): void {
    if (!localStorage.getItem('foo')) { 
      localStorage.setItem('foo', 'no reload') 
      location.reload() 
    } else {
      localStorage.removeItem('foo') 
    }
   
  }
  
}
