import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AddressDto } from '../dtos/addressDto';
import { ContactDto } from '../dtos/contactDto';
import { Genders } from '../constants/genders';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  addressDtos: AddressDto[];
  contactDtos: ContactDto[];

  bindAddressDtos(addressDtos: AddressDto[]) {
    this.addressDtos = addressDtos;
  }

  bindContactDtos(contactDtos: ContactDto[]) {
    this.contactDtos = contactDtos;
  }

  // constants
  genders = Genders;

  // fields
  selectedGender: string = "";
  firstName: string = "";
  middleName: string = "";
  lastName: string = "";
  addedClient: boolean = false;
  addedClientMessage: string = "Add Addresses"

  // events
  selectGender(value: string) {
    this.selectedGender = value;
  }
  
  create() {
    this.http.post(
      "https://localhost:44358/api/client",
      {
        firstName: this.firstName,
        middleName: this.middleName,
        lastName: this.lastName,
        gender: parseInt(this.selectedGender),
        addressesDto: this.addressDtos,
        contactsDto: this.contactDtos
    }
    ).subscribe(data => {
      this.addedClient = true;
      this.addedClientMessage = "Added";
    });
  }
}
