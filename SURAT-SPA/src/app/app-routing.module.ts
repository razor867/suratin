import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './core/home/home.component';
import { SuratmasukComponent } from './core/suratmasuk/suratmasuk.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    runGuardsAndResolvers: 'always',
    // canActivate: [AuthGuard],
  },
  {
    path: 'suratmasuk',
    component: SuratmasukComponent,
    runGuardsAndResolvers: 'always',
    // canActivate: [AuthGuard],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
