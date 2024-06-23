import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, delay, retry } from 'rxjs';
import { IContact } from '../model/contact.interface';
import { IContactCategory } from '../model/contactCategory.interface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  api: string = 'api/Contacts/'
  constructor(private http:HttpClient) { }


  getContacts(): Observable<Array<IContact>> {
    return this.http.get<Array<IContact>>(this.api);
  }
  getContact(id:number): Observable<IContact>{
    return this.http.get<IContact>(this.api+id);
  }
  deleteContact(id: number): void {
    this.http.delete(this.api + id);
  }
  addContact(form: IContact): Observable<IContact>{
    return this.http.put<IContact>(this.api, form);
  }
}
