import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../_Services/register.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userdetails:any;
  userid:any;

  constructor(private service:RegisterService) { }

  ngOnInit(): void {
    this.userDetails()
  }
  userDetails(){
    this.userid =localStorage.getItem('userid');
    this.service.GetUserDetails(this.userid).subscribe( result=>{
      if (result!= null){
        this.userdetails = result;

      }else{
        alert("hi Admin");
      }
    })
  }

}
