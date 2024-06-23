import { Component, OnInit } from '@angular/core';
import { IContact } from '../../model/contact.interface';
import { ContactService } from '../../service/contact.service';
import { Router } from '@angular/router';
import {FormsModule, ReactiveFormsModule} from "@angular/forms"
@Component({
  selector: 'app-contact-add',
  templateUrl: './contact-add.component.html',
  styleUrls: ['./contact-add.component.css'],
  standalone: true,
  imports:[
    ReactiveFormsModule,
    FormsModule
  ]
})

export class ContactAddComponent implements OnInit {
  contact!: IContact
  constructor(private cotactService: ContactService, private router:Router) { }

  ngOnInit() {
    this.contact = {
      id: 0,
      name: "",
      surame: "",
      email: "",
      password: "",
      contactCategoryId: 0,
      contactCategory: "",
      contactsubcategoryid: 0,
      contactsubcategory: "",
      number: "",
      birthdate: new Date(0)
  };

    }
    onSubmit(): void {
      this.cotactService.addContact(this.contact!).subscribe(  
        () => this.router.navigate(['/contacts'])     //subscribe makes user wait for response, so they can see new data upon returning to main page
      )
    }
  }


