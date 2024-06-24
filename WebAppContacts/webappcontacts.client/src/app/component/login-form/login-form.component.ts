import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../contact/service/user.service';
import { IUser } from '../../contact/model/user.interface';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],

})

//This authentication is not made secure yet

export class LoginFormComponent implements OnInit {
  username: string = ""
  password: string = ""
  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  login(){
    const user: IUser = {username: this.username, password: this.password}
    const token = this.userService.authenticate(user)
    if (token){
      localStorage.setItem('activeUser', token.username)
      location.reload()
    }
    else {
      console.log("Error when logging in")
    }
  }

  register() {
    const user: IUser = {username: this.username, password: this.password}
    this.userService.register(user)
    this.login()
  }
  
}
