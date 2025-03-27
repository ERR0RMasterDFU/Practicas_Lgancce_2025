import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeneroListComponent } from './components/genero/genero-list/genero-list.component';
import { GeneroPostFormComponent } from './components/genero/genero-post-form/genero-post-form.component';
import { GeneroDetailsComponent } from './components/genero/genero-details/genero-details.component';
import { GeneroPutFormComponent } from './components/genero/genero-put-form/genero-put-form.component';
import { ActorListComponent } from './components/actor/actor-list/actor-list.component';
import { ActorPostFormComponent } from './components/actor/actor-post-form/actor-post-form.component';
import { ActorDetailComponent } from './components/actor/actor-detail/actor-detail.component';
import { ActorPutFormComponent } from './components/actor/actor-put-form/actor-put-form.component';

const routes: Routes = [
  {path: 'generos', component: GeneroListComponent},
  {path: 'genero/:id', component: GeneroDetailsComponent},
  {path: 'genero/add', component: GeneroPostFormComponent},
  {path: 'genero/edit/:id', component: GeneroPutFormComponent},
  {path: 'actores', component: ActorListComponent},
  {path: 'actor/:id', component: ActorDetailComponent},
  {path: 'actor/add', component: ActorPostFormComponent},
  {path: 'actor/edit/:id', component: ActorPutFormComponent},
  {path: '', redirectTo: 'generos', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
