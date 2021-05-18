import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientDto } from '../dtos/clientDto';
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
        addressesDto: [
            {
                addressType: 1,
                line1: "street xyz",
                ine3: "Lynnwood",
                city: "Pretoria",
                stateProvince: "gauteng",
                areaCode: "0081",
                country: "South Africa"
            },
            {
                addressType: 2,
                line1: "street abc",
                line3: "Brooklyn",
                city: "Pretoria",
                stateProvince: "gauteng",
                areaCode: "0075",
                country: "South Africa"
            },
            {
                addressType: 2,
                line1: "street def",
                line3: "Brooklyn",
                city: "Pretoria",
                stateProvince: "gauteng",
                areaCode: "0075",
                country: "South Africa"
            }
        ],
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
