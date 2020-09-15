import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from "@angular/router";
import { stringify } from 'querystring';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: '././login.component.html',
  styleUrls: ['././login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service:AuthService,private router:Router, private service2:AccountService) { }

  public greeting = "";
  public i = 0;
  public vis = false;

  ngOnInit() {}

  onClick(uname, pass){
    this.service2.authenticate(uname, pass).subscribe(res=>{
      console.log(res)
      if(res.token!=null)
      {
        this.greeting=res.token
        localStorage.setItem('token',res.token)
        console.log(res)
        this.router.navigateByUrl('home');
      }
    })
  }
}