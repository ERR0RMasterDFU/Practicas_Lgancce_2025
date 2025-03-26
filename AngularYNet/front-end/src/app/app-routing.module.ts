import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeneroListComponent } from './components/genero/genero-list/genero-list.component';
import { GeneroPostFormComponent } from './components/genero/genero-post-form/genero-post-form.component';
import { GeneroDetailsComponent } from './components/genero/genero-details/genero-details.component';
import { GeneroPutFormComponent } from './components/genero/genero-put-form/genero-put-form.component';

const routes: Routes = [
  {path: 'generos', component: GeneroListComponent},
  {path: 'genero/:id', component: GeneroDetailsComponent},
  {path: 'genero/add', component: GeneroPostFormComponent},
  {path: 'genero/edit/:id', component: GeneroPutFormComponent},
  {path: '', redirectTo: 'generos', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
