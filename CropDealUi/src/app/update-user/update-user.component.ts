import { Component, OnInit } from '@angular/core';
import {  Validators,FormGroup,FormControl } from "@angular/forms";
import { RegisterService } from '../_Services/register.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {
  userId:any

  constructor(private service:RegisterService) { }

  ngOnInit(): void {
  }
  updateform= new FormGroup({
    
    userAddress: new FormControl('',[Validators.required,Validators.pattern("^[a-zA-Z0-9 _.-]*$")]),
    userPhnumber:new FormControl('',[Validators.required,Validators.pattern("^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$")]),
    userEmail: new FormControl('', [Validators.required, Validators.pattern("([!#-'*+/-9=?A-Z^-~-]+(\.[!#-'*+/-9=?A-Z^-~-]+)*|\"\(\[\]!#-[^-~ \t]|(\\[\t -~]))+\")@([!#-'*+/-9=?A-Z^-~-]+(\.[!#-'*+/-9=?A-Z^-~-]+)*|\[[\t -Z^-~]*])")]),
    
    
  })
  get f(){
   
    return this.updateform.controls;
  }

  changeRole(e:any) {
    console.log(e.target.value);
  }
  update(){
    this.userId=localStorage.getItem('userid')
    this.service.update(this.userId,this.updateform.value).subscribe();
    alert("updation successfull !");
    
}
}
