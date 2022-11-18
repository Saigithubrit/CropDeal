import { Component, OnInit } from '@angular/core';
import { Payment } from '../_Models/payment';
import { PaymentService } from '../_Services/payment.service';
import { ViewcropsService } from '../_Services/viewcrops.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-crops',
  templateUrl: './view-crops.component.html',
  styleUrls: ['./view-crops.component.css']
})
export class ViewCropsComponent implements OnInit {

  constructor(private service:ViewcropsService, private ser:PaymentService,private route:Router ) { 
    this.viewcrop();
   }
    cropdata:any;
    userid:any;
    

  ngOnInit(): void {

  }
viewcrop(){
  this.service.ViewCrop().subscribe(data=>{
    this.cropdata=data;
   
   },(err)=>{
     
    if(err.status==403){
      this.route.navigate(['/Unauthorized'])
     
    }else{

      alert("Some error occured! come back later");
    }
  } );
  }

   payment(cropAdId:any,farmerId:any){
    this.userid=localStorage.getItem('userid')
    var payment = new Payment();
    payment.cropAdid=cropAdId;
    payment.farmerId=farmerId;
    payment.userId=this.userid;
    this.ser.payment(payment).subscribe(result=>{
      if(result!=null){
      
       this.route.navigate(['/PaymentSuccess'])
      
        

      }
    })
   }
    
   

}



