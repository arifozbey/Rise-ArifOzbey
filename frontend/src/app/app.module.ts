import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceService } from './service.service';
import { ModalComponent } from './modal/modal.component';
import { RaporComponent } from './rapor/rapor.component';
import { RapordetayComponent } from './rapordetay/rapordetay.component';
import { RouterModule } from '@angular/router';
import { KisilerComponent } from './kisiler/kisiler.component';

@NgModule({
  declarations: [
    AppComponent,
    ModalComponent,
    RaporComponent,
    RapordetayComponent,
    KisilerComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,

  ],

  providers: [ServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
