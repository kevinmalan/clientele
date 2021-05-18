import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ContactType } from '../constants/contactType';
import { ContactDto } from '../dtos/contactDto';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  addContacts() {
    this.contactDtos = [
      {
        contactType: this.cellContactType,
        msisdn: this.cellMsisdn
      },
      {
        contactType: this.homeContactType,
        msisdn: this.homeMsisdn
      },
      {
        contactType: this.workContactType,
        msisdn: this.workMsisdn
      }
    ];

    this.contactDtoEvent.emit(this.contactDtos);
  }

  // fields
  cellContactType = ContactType.Cell;
  cellMsisdn = "";

  homeContactType = ContactType.Home;
  homeMsisdn = "";

  workContactType = ContactType.Work;
  workMsisdn = "";

  @Output() contactDtoEvent = new EventEmitter();

  contactDtos: ContactDto[];
}
