import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private router: Router){}

  navigateClientDashboard() {
    this.router.navigateByUrl('/clientDashboard');
  }
  
  navigateAddClient() {
    this.router.navigateByUrl('/clients');
  }
}