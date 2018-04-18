import { Component, OnInit } from '@angular/core';
import { Contact } from '../contact'
import { ContactService } from '../contact.service'

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  addingNew: boolean = false;
  contacts: Contact[];

  constructor(private _contactService: ContactService) { }

  ngOnInit() {
    this.getContacts();
  }

  getContacts(): void {
    this._contactService.getContacts()
      .subscribe(result => this.contacts = result);
  }

  addNew(fName: string, lName: string, ph: string) {
    let person = new Contact(fName, lName, ph);
    
    this._contactService.addContact(person)
      .subscribe(result => {
        this.contacts.push(result);
        this.toggleAdd();
    });
  }

  delete(contact: Contact): void {
    this.contacts = this.contacts.filter(h => h !== contact);
    this._contactService.deleteContact(contact).subscribe();
  }

  toggleAdd() {
    this.addingNew = !this.addingNew;
  }

}
