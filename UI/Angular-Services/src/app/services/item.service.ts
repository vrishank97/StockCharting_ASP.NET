import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Observable } from "Rxjs";
import { Item } from '../item';
import { JsonPipe } from '@angular/common';
import { environment } from 'src/environments/environment';


const Requestheaders={headers:new HttpHeaders({
  'Content-Type': 'application/json',
  'Authorization': 'Bearer '+localStorage.getItem('token')
})}
@Injectable({
  providedIn: 'root'
})
export class ItemService {
url:string= environment.gatewayURI + '/Admin/'
  constructor(private http:HttpClient) { }
  public GetAll():Observable<Item[]>
  {
    return this.http.get<Item[]>(this.url+'Companies/All',Requestheaders)
  }
  public GetById(id:string):Observable<Item>
  {
    return this.http.get<Item>(this.url+'Companies/'+id,Requestheaders)
  }
  public GetIPOById(id:string):Observable<Item>
  {
    return this.http.get<Item>(this.url+'IPO/'+id,Requestheaders)
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
    return this.http.delete(this.url+'Companies/Delete/'+id,Requestheaders)
  }


}
