import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/item';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {

  itemForm:FormGroup;
  submitted=false;
list:Item[];
item:Item;
  constructor(private builder:FormBuilder,private service:ItemService) {
      this.service.GetAll().subscribe(res=>{
        this.list=res;
        console.log(this.list);
      },err=>{
        console.log(err)
      })
  }

  ngOnInit() {
    this.itemForm=this.builder.group({
      CompanyCode:[''],
      CompanyName:[''],
      Turnover:[''],
      CEO:[''],
    });
  }
  get f() { return this.itemForm.controls; }

  onSubmit() {
      this.submitted = true;
      this.Add();
  }

  onReset() {
      this.submitted = false;
      this.itemForm.reset();
  }
  Search()
  {
    let id=this.itemForm.value["CompanyCode"];
    this.service.GetById(id).subscribe(res=>{
      this.item=res;
      console.log(this.item);
          this.itemForm.setValue({
    id:this.item.CompanyCode,
    name:this.item.CompanyName,
    price:this.item.Turnover,
    stock:this.item.CEO,
          })

    })
    this.list=[this.item]
  }
  Add()
  {
    this.item=new Item();
    this.item.CompanyCode=this.itemForm.value["CompanyCode"];
    this.item.CompanyName=this.itemForm.value["CompanyName"];
    this.item.Turnover=this.itemForm.value["Turnover"];
    this.item.CEO=this.itemForm.value["CEO"];
    console.log(this.item);
    this.service.AddItem(this.item).subscribe(res=>{
      console.log('Record Added')
    })
  }
    Update()
  {
    this.item.CompanyCode=this.itemForm.value["CompanyCode"];
    this.item.CompanyName=this.itemForm.value["CompanyName"];
    this.item.Turnover=this.itemForm.value["Turnover"];
    this.item.CEO=this.itemForm.value["CEO"];
    console.log(this.item);
    this.service.UpdateItem(this.item).subscribe(res=>{
      console.log('Record Updated')
    })

  }
Delete()
{
  let id=this.itemForm.value["id"];
  this.service.DeleteItem(id).subscribe(res=>{
    console.log('Record deleted');
  },err=>{
    console.log(err);
  })
}
}
