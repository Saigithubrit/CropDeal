import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserStatus } from '../_Models/user-status';
import { ChangestatusService } from '../_Services/changestatus.service';
import { RegisterService } from '../_Services/register.service';

@Component({
  selector: 'app-change-user-status',
  templateUrl: './change-user-status.component.html',
  styleUrls: ['./change-user-status.component.css']
})
export class ChangeUserStatusComponent implements OnInit {

  constructor(private service:RegisterService,private ser : ChangestatusService,private route:Router) { }
  profile:any

  ngOnInit(): void {
    this.getProfies();
  }
  getProfies(){
    this.service.GetUsers().subscribe(result =>{
      if(result!=null){
      this.profile=result;
    }else{
      alert("No users found");
    }
    },(err)=>{
     
      if(err.status==403){
        this.route.navigate(['/Unauthorized'])
       
      }else{
  
        alert("Some error occured! come back later");
      }
    }
    );

  }
  ChangeStatus(userId:any,status:any){
    var userstatus = new UserStatus()
    userstatus.userId=userId
    if(status=="ACTIVE"){
      status="INACTIVE";
    }
    else{
      status="ACTIVE";
    }
    userstatus.userStaus=status
    this.ser.changeStatus(userstatus).subscribe(result=>{
      if(result!=null){
          
          alert("Status Changed sucessfully");
      }
    })
    window.location.reload();
  }

}
