import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Contact } from './contact'
import { CONTACTS } from './mock-contacts' 

@Injectable()
export class ContactService {
  private apiUrl = 'http://localhost:51702/api/'

  constructor(private _http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this._http.get<Contact[]>(this.apiUrl+ 'Contacts');
  }

  getContact(id: number): Observable<Contact> {
    return this._http.get<Contact>(this.apiUrl+ 'Contacts/' + id);
  }
}
