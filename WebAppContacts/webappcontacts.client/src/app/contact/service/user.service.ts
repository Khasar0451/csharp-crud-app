import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from '../model/user.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  api: string = 'api/Users/'
  constructor(private http:HttpClient) { }

  private getUsers() {
    return JSON.parse(localStorage.getItem('Users') || '{}');
  }
 
  authenticate(user: IUser) {    
    let users = []
    users = this.getUsers();
    return users.find((x: { username: string; password: string; }) =>
       x.username === user.username && x.password === user.username)

    //return this.http.post<IUser>(this.api + "login", user);
  }

  register(user: IUser): void {
    let users = this.getUsers()
    if (Object.keys(users).length === 0 ){
      users = [user]

    }
    else {
      users.push(user)
    }
    console.log(users)

    localStorage.setItem('Users', JSON.stringify(users))
  }
  
}
