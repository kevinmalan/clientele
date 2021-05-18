import { Component, Output, OnInit, EventEmitter  } from '@angular/core';
import { AddressDto } from '../dtos/addressDto';
import { AddressType } from '../constants/addressType';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    
  }

  addedAddresses: boolean = false;
  addAddressMessage: string = "Add Addresses"

  addAddresses() {
    this.addedAddresses = true;
    this.addAddressMessage = "Added";
    
    this.addressDtos = [
      {
        addressType : this.residentialAddressType,
        line1 : this.residentialLine1,
        line2 : this.residentialLine2,
        line3 : this.residentialLine3,
        city : this.residentialCity,
        stateProvince : this.residentialStateProvince,
        areaCode : this.residentialAreaCode,
        country : this.residentialCountry
      },
      {
        addressType : this.workAddressType,
        line1 : this.workLine1,
        line2 : this.workLine2,
        line3 : this.workLine3,
        city : this.workCity,
        stateProvince : this.workStateProvince,
        areaCode : this.workAreaCode,
        country : this.workCountry
      },
      {
        addressType : this.postalAddressType,
        line1 : this.postalLine1,
        line2 : this.postalLine2,
        line3 : this.postalLine3,
        city : this.postalCity,
        stateProvince : this.postalStateProvince,
        areaCode : this.postalAreaCode,
        country : this.postalCountry
      }
    ];

    this.addressDtoEvent.emit(this.addressDtos);
  }

  // fields
  residentialAddressType: number = AddressType.Residential
  residentialLine1: string = "";
  residentialLine2: string = "";
  residentialLine3: string = "";
  residentialCity: string = "";
  residentialStateProvince: string = "";
  residentialAreaCode: string = "";
  residentialCountry: string = "";

  workAddressType: number = AddressType.Work
  workLine1: string = "";
  workLine2: string = "";
  workLine3: string = "";
  workCity: string = "";
  workStateProvince: string = "";
  workAreaCode: string = "";
  workCountry: string = "";

  postalAddressType: number = AddressType.Postal
  postalLine1: string = "";
  postalLine2: string = "";
  postalLine3: string = "";
  postalCity: string = "";
  postalStateProvince: string = "";
  postalAreaCode: string = "";
  postalCountry: string = "";

  @Output() addressDtoEvent = new EventEmitter();

  addressDtos: AddressDto[];
}