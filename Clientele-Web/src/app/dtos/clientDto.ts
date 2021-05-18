import { AddressDto } from './addressDto';
import { ContactDto } from './contactDto';

export interface ClientDto
{
    firstName: string,
    middleName: string,
    lastName: string,
    gender: number,
    dateOfBirth: Date,
    addressesDto: AddressDto[],
    contactsDto: ContactDto[]
}