import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientComponent } from './client/client.component';
import { AddressComponent } from './address/address.component';
import { ContactComponent } from './contact/contact.component';
import { ClientDashboardComponent } from './client-dashboard/client-dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    AddressComponent,
    ContactComponent,
    ClientDashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
