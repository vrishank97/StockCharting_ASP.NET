import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';
import { RouterModule, Router } from '@angular/router';
import { User } from 'src/app/Models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private service:AccountService, private router:Router) { }
  user:User = <User>{ };

  ngOnInit() {
  }

  onClick(uname, pass, mail, num){
    this.user.username=uname
    this.user.password=pass
    this.user.email=mail
    this.user.mobile=num
    this.user.usertype="0"
    this.user.confirmed="0"
    console.log(this.user)



    this.service.register(this.user).subscribe(res=>{
      console.log(res)
    })
  }

}
