import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ContactService }  from '../contact.service';

import { Contact } from '../contact'

@Component({
  selector: 'app-contact-detail',
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.css']
})
export class ContactDetailComponent implements OnInit {

  @Input() contact: Contact;

  constructor(
    private _route: ActivatedRoute,
    private _contactService: ContactService,
    private _loc: Location
  ) { }

  ngOnInit() {
    this.getContact();
  }

  getContact(): void {
    const id = +this._route.snapshot.paramMap.get('id');
    this._contactService.getContact(id)
      .subscribe(result => this.contact = result);
  }

  goBack(): void {
    this._loc.back();
  }

}
