import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-farmer-landing-page',
  templateUrl: './farmer-landing-page.component.html',
  styleUrls: ['./farmer-landing-page.component.css']
})
export class FarmerLandingPageComponent implements OnInit {

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
