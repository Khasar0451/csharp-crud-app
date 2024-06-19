import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IContact } from '../entities/contact.interface';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http:HttpClient) { }

  getContacts(): Observable<Array<IContact>>{
    return this.http.get<Array<IContact>>('contacts/data.json')
  }
}
