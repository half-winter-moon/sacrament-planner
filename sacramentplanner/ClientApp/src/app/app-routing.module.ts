import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SacramentComponent } from './sacrament/sacrament.component';
import { SacramentEditComponent } from './sacrament/sacrament-edit/sacrament-edit.component';
import { SacramentListComponent } from './sacrament/sacrament-list/sacrament-list.component';
import { SacramentDetailsComponent } from './sacrament/sacrament-details/sacrament-details.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/sacrament', pathMatch: 'full' },
  {
    path: 'sacrament',
    component: SacramentComponent,
    children: [
      {
        path: 'new',
        component: SacramentEditComponent,
        // pass in the id of the contact item in contact list to display the correct content and route
      },
      {
        path: ':id',
        component: SacramentDetailsComponent,
      },
      {
        path: ':id/edit',
        component: SacramentEditComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
