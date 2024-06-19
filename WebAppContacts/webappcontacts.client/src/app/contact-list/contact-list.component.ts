import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContactService } from '../services/contact.service';
import { IContact } from '../entities/contact.interface';
@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent implements OnInit{

   contacts: Array<IContact> = [];

  constructor(private contactService:ContactService){}
  
  ngOnInit(): void {
    this.contactService.getContacts().subscribe(
      // contacts => {
      //   for (var contact of contacts){
      //     this.contacts.push(contact);
      //   }
      // }
      contacts => {
        this.contacts = contacts;
      }
    )
  }
}
