import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientDashboardDto } from '../dtos/clientDashboardDto';
import { Genders } from '../constants/genders';

@Component({
  selector: 'app-client-dashboard',
  templateUrl: './client-dashboard.component.html',
  styleUrls: ['./client-dashboard.component.css']
})
export class ClientDashboardComponent implements OnInit {

  constructor(private http: HttpClient) { }

  clients: ClientDashboardDto[] = [];

  genders = Genders;

  ngOnInit(): void {
    this.http.get(
      "https://localhost:44358/api/client",
    ).subscribe((data: any) => {
      data.forEach(item => {
        this.clients.push({
          firstName: item.firstName,
          middleName: item.middleName,
          lastName: item.lastName,
          gender: this.genders.filter(g => g.value == item.gender)[0].name
        });
      });
    });
  }
}