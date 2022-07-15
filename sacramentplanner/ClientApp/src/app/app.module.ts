import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SacramentComponent } from './sacrament/sacrament.component';
import { SacramentEditComponent } from './sacrament/sacrament-edit/sacrament-edit.component';
import { SacramentListComponent } from './sacrament/sacrament-list/sacrament-list.component';
import { SacramentDetailsComponent } from './sacrament/sacrament-details/sacrament-details.component';
import { AppRoutingModule } from './app-routing.module';
import { SacramentItemComponent } from './sacrament/sacrament-item/sacrament-item.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SacramentComponent,
    SacramentEditComponent,
    SacramentListComponent,
    SacramentDetailsComponent,
    SacramentItemComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    ReactiveFormsModule,
    // RouterModule.forRoot([
    //   { path: '', component: HomeComponent, pathMatch: 'full' },
    //   { path: 'counter', component: CounterComponent },
    //   { path: 'fetch-data', component: FetchDataComponent },
    // ]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
