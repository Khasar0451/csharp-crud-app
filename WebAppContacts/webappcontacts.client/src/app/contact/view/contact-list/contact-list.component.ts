import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ContactService } from '../../service/contact.service';
import { IContact } from '../../model/contact.interface';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent implements OnInit{

   contacts: Array<IContact> = [];

  constructor(private contactService:ContactService){}  //service injection

  ngOnInit(): void {
    this.contactService.getContacts().subscribe(
      contacts => { this.contacts = contacts; }
    )
  }
}
