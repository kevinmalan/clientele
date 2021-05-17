import { AddressDto } from './addressDto';
import { ContactDto } from './contactDto';

export interface ClientDto
{
    uniqueId: string,
    firstName: string,
    middleName: string,
    lastName: string,
    gender: string,
    dateOfBirth: Date,
    addressesDto: AddressDto[],
    contactsDto: ContactDto[]
}