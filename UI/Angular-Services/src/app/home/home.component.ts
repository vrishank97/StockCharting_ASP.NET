import { Component, OnInit } from '@angular/core';
import { Item } from '../item';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ItemService } from '../services/item.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private router:Router, private service:ItemService) { }

  public item:Item = <Item>{ };
  public res=null;
  public greeting = null;
  public list:Item[]

  ngOnInit() {}


  onClick(cname){
    this.service.GetById(cname).subscribe(res=>{
      this.list = [res]
    })
  }
  onClickIPO(iponame){
    this.service.GetIPOById(iponame).subscribe(res=>{
      console.log(res)
    })
  }
}
