import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private router: Router, private http: HttpClient){}

  navigateClientDashboard() {
    this.router.navigateByUrl('/clientDashboard');
  }
  
  navigateAddClient() {
    this.router.navigateByUrl('/clients');
  }

  downloadCsv() {

    this.http.get(
      "https://localhost:44358/api/client/file/csv",
      { responseType: 'blob' }
    ).subscribe(blob => {
      saveAs(blob, `ClientsExport.csv`, {
        type: 'text/plain;'
     });
    });
  }
}