import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: []
})
export class RegisterComponent implements OnInit {

  constructor(public service: AccountService) { }

  ngOnInit() {
  }

  onSubmit(){
    this.service.register().subscribe(
      (res:any) => {
        if(res.succeeded){
          this.service.formModel.reset()
        }
        else{
          res.errors.forEach(element => {
            switch (element.code){
              case 'DuplicateUserName':
                break;
              default:
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    )
  }

}
