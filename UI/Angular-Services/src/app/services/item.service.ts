import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable } from "Rxjs";
import { Item } from '../item';
import { JsonPipe } from '@angular/common';
const Requestheaders={headers:new HttpHeaders({
  'Content-Type': 'application/json',
  'Authorization': 'Bearer '+localStorage.getItem('token')
})}
@Injectable({
  providedIn: 'root'
})
export class ItemService {
url:string='http://localhost:8080/Admin/'
  constructor(private http:HttpClient) { }
  public GetAll():Observable<Item[]>
  {
    return this.http.get<Item[]>(this.url+'Companies/All',Requestheaders)
  }
  public GetById(id:string):Observable<Item>
  {
    return this.http.get<Item>(this.url+'Companies/'+id,Requestheaders)
  }
  public AddItem(item:Item):Observable<any>
  {
    return this.http.post(this.url+'Companies/Add',JSON.stringify(item),Requestheaders);
  }
  public UpdateItem(item:Item):Observable<any>
  {
    return this.http.put<any>(this.url+'Companies/Update',JSON.stringify(item),Requestheaders);
  }public DeleteItem(id:string):Observable<any>
  {
    return this.http.delete<Item>(this.url+'Companies/Delete/'+id,Requestheaders)
  }


}