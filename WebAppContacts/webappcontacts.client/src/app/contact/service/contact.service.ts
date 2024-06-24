import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, delay, retry } from 'rxjs';
import { IContact } from '../model/contact.interface';
import { IContactCategory } from '../model/contactCategory.interface';
import { IContactSubcategory } from '../model/contactSubcategory.interface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  api: string = 'api/Contacts/'
  constructor(private http:HttpClient) { }

  getContactsCategories(): Observable<Array<IContactCategory>> {
    return this.http.get<Array<IContactCategory>>(this.api + 'categories');
  }
  getContactsSubcategories(): Observable<Array<IContactSubcategory>> {
    return this.http.get<Array<IContactSubcategory>>(this.api + 'subcategories');
  }
  getContacts(): Observable<Array<IContact>> {
    return this.http.get<Array<IContact>>(this.api);
  }
  getContact(id:number): Observable<IContact>{
    return this.http.get<IContact>(this.api+id);
  }
  deleteContact(id: number): Observable<IContact> {
    return this.http.delete<IContact>(this.api + id);
  }
  addContact(form: IContact): Observable<IContact>{
    return this.http.put<IContact>(this.api + 'add', form);
  }
  editContact(patchOperations: any[], id: number): Observable<IContact>{
    //return this.http.patch<IContact>(this.api + 'update/' + form.id, form);
    return this.http.patch<IContact>(this.api + 'update/' + id, patchOperations);
  }

}
