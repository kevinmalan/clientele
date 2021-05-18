import { Component, OnInit } from '@angular/core';
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
}