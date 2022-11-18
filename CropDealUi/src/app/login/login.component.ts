import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators,FormGroup,FormControl } from "@angular/forms";
import { Router } from '@angular/router';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  rolelist: any = ['Admin', 'Farmer', 'Dealer']
  responsedata:any;
  email:any;
  userid:any;


 errormessage='';

  constructor(public fb: FormBuilder, private service:AccountService,private route:Router  ) { }

  
  ngOnInit(): void {
  }
  form = new FormGroup({
  Role: new FormControl('', Validators.required),
  Email: new FormControl('',Validators.required),
  Password: new FormControl('',Validators.required)

  });
  get f(){
    return this.form.controls;
  }

 login(){
  if(this.form.valid){
    this.service.proceedLogin(this.form.value).subscribe(result=>{
      if(result!=null){
        this.responsedata=result;
        
        localStorage.setItem('token',this.responsedata.token);
        localStorage.setItem('userid',JSON.stringify(this.responsedata.userId));
        localStorage.setItem('role', JSON.stringify(this.form.value.Role));
        
        
        
        if(this.form.value.Role=='Admin')
        {
        

          this.route.navigate(['/Adminlanding'])
        }else if(this.form.value.Role=='Dealer'){
          
          this.route.navigate(['/Dealerlanding'])
        }else{
          
          this.route.navigate(['/Farmerlanding'])
        }
      
      }

    }, (err)=>{
     
      if(err.status==400){
        alert("your account is blocked ! please contact Administrator.");
      }else{

      this.errormessage=err.message;
      }
    }
    )

  }
 }

 changeRole(e:any) {
  console.log(e.target.value);
}

  
   

}


