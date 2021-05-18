import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AddressDto } from '../dtos/addressDto';
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

  bindAddressDtos(addressDtos: AddressDto[]) {
    this.addressDtos = addressDtos;
  }

  // constants
  genders = Genders;

  // fields
  selectedGender: number = 1;
  firstName: string = "";
  middleName: string = "";
  lastName: string = "";

  // events
  selectGender(value: number) {
    this.selectedGender = value;
  }

  create() {
    this.http.post(
      "https://localhost:44358/api/client",
      {
        firstName: this.firstName,
        middleName: this.middleName,
        lastName: this.lastName,
        gender: this.selectedGender,
        dateOfBirth: "1990-12-17",
        addressesDto: this.addressDtos,
        contactsDto: [
            {
                contactType: 1,
                msisdn: "27843904009"
            },
            {
                ontactType: 3,
                msisdn: "2543904009"
            }
        ]
    
    }
    ).subscribe(data => {
      console.log("created");
      console.log(data);
    });
  }
}
