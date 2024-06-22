import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContact } from '../model/contact.interface';
import { IContactCategory } from '../model/contactCategory.interface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http:HttpClient) { }

  // getContacts(): Observable<Array<IContact>>{
  //   return this.http.get<Array<IContact>>('contacts/data.json')
  // }
  /*getContacts(): Observable<Array<IContact>>{*/
  getContacts(): Observable<Array<IContact>> {
    return this.http.get<Array<IContact>>('/api/Contacts');
  }
  getContact(id:number): Observable<IContact>{
    return this.http.get<IContact>('/api/Contacts/'+id);
  }
  getContactsCategories(): Observable<Array<IContactCategory>> {
    return this.http.get<Array<IContactCategory>>('/api/Contacts/categories');
  }
  getContactCategory(id: number): Observable<IContactCategory>{
    return this.http.get<IContactCategory>('api/Contacts/categories/'+id);
  }
}
