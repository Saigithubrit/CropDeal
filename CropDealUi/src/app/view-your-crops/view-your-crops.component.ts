import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Userid } from '../_Models/userid';
import { ViewcropsService } from '../_Services/viewcrops.service';

@Component({
  selector: 'app-view-your-crops',
  templateUrl: './view-your-crops.component.html',
  styleUrls: ['./view-your-crops.component.css']
})
export class ViewYourCropsComponent implements OnInit {
  cropdata:any
  userId:any

  constructor(private service:ViewcropsService,private route:Router) { 
    this.viewyourcrop();
  }

  ngOnInit(): void {
    
  }

  viewyourcrop(){
       this.userId=localStorage.getItem('userid')
      
    this.service.ViewYourCrop(this.userId).subscribe(data=>{
      this.cropdata=data;

      console.log(this.cropdata.cropAdId);
     },(err)=>{
     
      if(err.status==403){
        this.route.navigate(['/Unauthorized'])
       
      }else{
  
        alert("Some error occured! come back later");
      }
    } );
  
  }

}
