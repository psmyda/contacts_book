import { Component, OnInit } from '@angular/core';
import { Contact } from '../contact'
import { ContactService } from '../contact.service'

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  contacts: Contact[];

  constructor(private _contactService: ContactService) { }

  ngOnInit() {
    this.getContacts();
  }

  getContacts(): void {
    this._contactService.getContacts()
      .subscribe(result => this.contacts = result);
  }

}
