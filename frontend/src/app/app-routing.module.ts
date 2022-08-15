import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { KisilerComponent } from './kisiler/kisiler.component';
import { RaporComponent } from './rapor/rapor.component';

const routes: Routes = [
  { path: 'kisiler', component: KisilerComponent },
  { path: 'rapor', component: RaporComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
