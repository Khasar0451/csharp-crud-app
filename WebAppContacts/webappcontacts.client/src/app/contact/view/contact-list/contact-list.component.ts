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

  getCat(i: number): string {
    var cat! : string;
    this.contactService.getContactCategory(i).
      subscribe(category => {
        console.log(category)
      });
    return cat;
  }

  ngOnInit(): void {
    this.contactService.getContacts().subscribe(
      contacts => {
        
        this.contacts = contacts;
        var i = 0;
        for (let contact in contacts) {
             i += 1
            contacts[i].contactCategory = this.getCat(contacts[i].contactCategoryId);
        }
      }
    )
  }
}
