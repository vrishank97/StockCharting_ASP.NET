import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';
import { Token } from '../token';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  path:string = environment.gatewayURI;

  constructor(private http:HttpClient) { }

  public authenticate(username:string, password:string):Observable<Token> {
    return this.http.get<Token>(`${this.path}/Account/Validate/${username}/${password}`);
  }

  public status() {
    return this.http.get(`${this.path}/Account/Status`);
  }

  public register(user:User) {
    return this.http.post(`${this.path}/Account/AddUser`, user);
  }

  public isTaken(username:string):Observable<boolean>{
    return this.http.get<boolean>(`${this.path}/Account/isTaken/${username}`);
  }
}