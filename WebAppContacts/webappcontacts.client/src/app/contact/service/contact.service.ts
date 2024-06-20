import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContact } from '../model/contact.interface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http:HttpClient) { }

  // getContacts(): Observable<Array<IContact>>{
  //   return this.http.get<Array<IContact>>('contacts/data.json')
  // }
  /*getContacts(): Observable<Array<IContact>>{*/
  getContacts(): Observable<Array<string>>{
    return this.http.get < Array<string>>('/api/contacts');
  }
  getContact(id:string): Observable<IContact>{
    return this.http.get<IContact>('contacts/data.json/'+id);
  }
}
