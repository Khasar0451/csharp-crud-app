import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, retry, delay } from 'rxjs';
import { ContactService } from '../../service/contact.service';
import { IContact } from '../../model/contact.interface';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent implements OnInit{
  isLoggedIn: boolean = false
  contacts: Array<IContact> | undefined ;
  constructor(private contactService:ContactService){}  //service injection

  ngOnInit(): void {
    if (localStorage.getItem('activeUser') != null){
      this.isLoggedIn = true;
    }
    this.contactService.getContacts().pipe(
      retry({count:10, delay:1000})).subscribe(  //ensures backend have time to load
      contacts => { this.contacts = contacts; }
    )
  }

  onDelete(contact: IContact): void {
    this.contactService.deleteContact(contact.id).subscribe(() => this.ngOnInit())    //reload page 
  }
}
