import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Contact } from './contact'

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }  )
};

@Injectable()
export class ContactService {
  private apiUrl = 'http://localhost:51702/api/Contacts'

  constructor(private _http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this._http.get<Contact[]>(this.apiUrl);
  }

  getContact(id: number): Observable<Contact> {
    return this._http.get<Contact>(this.apiUrl+ '/' + id);
  }

  addContact(contact: Contact): Observable<any> {
    return this._http.post(this.apiUrl, contact, httpOptions)
  }

  updateContact(contact: Contact): Observable<any> {
    return this._http.put(this.apiUrl, contact, httpOptions)
  }

  deleteContact(contact: Contact | number): Observable<any>{
    const id = typeof contact === 'number' ? contact : contact.id;
    const url = `${this.apiUrl}/${id}`;
  
    return this._http.delete<Contact>(url, httpOptions);
  }
}