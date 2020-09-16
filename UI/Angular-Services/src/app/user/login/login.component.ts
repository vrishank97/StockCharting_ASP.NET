import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { stringify } from 'querystring';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: '././login.component.html',
  styleUrls: ['././login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router:Router, private service:AccountService) { }

  public greeting = "";
  public i = 0;
  public vis = false;
  public warning = "";

  ngOnInit() {}

  onClick(uname, pass){
    this.service.authenticate(uname, pass).subscribe(res=>{
      console.log(res)
      if(res.token!=null)
      {
        this.greeting=res.token
        localStorage.setItem('token',res.token)
        console.log(res)
        if(uname!="Admin"){
          this.router.navigateByUrl('home');
        }
        if(uname=="Admin"){
          this.router.navigateByUrl('admin');
        }
      }
      else{
        this.warning="Incorrect Password"
      }
    })
  }
}