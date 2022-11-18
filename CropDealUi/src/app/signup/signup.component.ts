import { Component, OnInit } from '@angular/core';
import {  Validators,FormGroup,FormControl } from "@angular/forms";
import { RegisterService } from '../_Services/register.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {


  responsedata:any;
  rolelist: any = [ 'Farmer', 'Dealer']

  constructor(private service:RegisterService,private route:Router) { }

  ngOnInit(): any {
    
  }
  signupform= new FormGroup({
    userName: new FormControl('',[Validators.required,Validators.pattern("^[A-Za-z ]+$")]),
    userAddress: new FormControl('',[Validators.required,Validators.pattern("^[a-zA-Z0-9_ .-]*$")]),
    userPhnumber:new FormControl('',[Validators.required,Validators.pattern("^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$")]),
    userEmail: new FormControl('', [Validators.required, Validators.pattern("([!#-'*+/-9=?A-Z^-~-]+(\.[!#-'*+/-9=?A-Z^-~-]+)*|\"\(\[\]!#-[^-~ \t]|(\\[\t -~]))+\")@([!#-'*+/-9=?A-Z^-~-]+(\.[!#-'*+/-9=?A-Z^-~-]+)*|\[[\t -Z^-~]*])")]),
    userPassword: new FormControl('',[Validators.required,Validators.pattern("^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$")]),
    userAccnumber: new FormControl('',[Validators.required,Validators.pattern("[0-9]{9,14}")]),
    userIfsc: new FormControl('',[Validators.required,Validators.pattern("^[A-Za-z0-9]+$")]),
    userBankname: new FormControl('',[Validators.required,Validators.pattern("^[A-Za-z ]+$")]),
    userType: new FormControl('',Validators.required)
    
  })

  get f(){
   
    return this.signupform.controls;
  }

  changeRole(e:any) {
    console.log(e.target.value);
  }

  Signup(){
    console.log(this.signupform.value)
  if(this.signupform.valid){
    this.service.proceedSignup(this.signupform.value).subscribe(result=>{
      if(result!=null){
       alert("Registraion Sucessfull");
       this.route.navigate(['/Login'])
        

      }
    })
  }
}

}
