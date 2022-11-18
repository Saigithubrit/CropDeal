import { Component, OnInit } from '@angular/core';
import { CropsService } from '../_Services/crops.service';
import {  Validators,FormGroup,FormControl } from "@angular/forms";
import { CropOnSale } from '../_Models/crop-on-sale';
import { CropsonsaleService } from '../_Services/cropsonsale.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-crop-on-sale',
  templateUrl: './crop-on-sale.component.html',
  styleUrls: ['./crop-on-sale.component.css']
})
export class CropOnSaleComponent implements OnInit {
croplist:any
userId:any
croptype: any = [ 'Vegetable', 'Fruit','Cereal']
  constructor(private service:CropsService, private ser:CropsonsaleService,private route:Router) { }

  ngOnInit(): void {
    this.getcrop()
  }
  cropform= new FormGroup({
    
     cropName: new FormControl('',  [Validators.required,Validators.pattern("^[A-Za-z ]+$")]),
    cropType:  new FormControl('',Validators.required),
    cropQty: new FormControl('',[Validators.required,Validators.pattern("[0-9]{1,9}")]),
    cropPrice: new FormControl('',[Validators.required,Validators.pattern("[(0-9)+.?(0-9)*]+")]),
    cropId: new FormControl('',Validators.required)
    
    
    
  })

  get f(){
   
    return this.cropform.controls;
  }

  changeRole(e:any) {
    console.log(e.target.value);
  }
  getcrop(){
    this.service.getcrops().subscribe(data=>{
      this.croplist=data;
    },(err)=>{
     
      if(err.status==403){
        this.route.navigate(['/Unauthorized'])
       
      }else{
  
        alert("Some error occured! come back later");
      }
    })

    }
    cropOnSale(){
      var croponsale = new CropOnSale();
      croponsale.cropId = this.cropform.value.cropId;
      croponsale.cropName=this.cropform.value.cropName;
      croponsale.cropPrice=this.cropform.value.cropPrice,
      croponsale.cropQty=this.cropform.value.cropQty,
      croponsale.cropType=this.cropform.value.cropType
      this.userId =localStorage.getItem('userid')
      croponsale.farmerId=this.userId;
      this.ser.croponsale(croponsale).subscribe(result=>{
        if(result!=null){
         alert("Crop is posted on sale Sucessfully");
         this.route.navigate(['/Farmerlanding'])
        
          
  
        }
      })

      

    }
  }
 
