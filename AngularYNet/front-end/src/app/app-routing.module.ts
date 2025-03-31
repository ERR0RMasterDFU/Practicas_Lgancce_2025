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
import { esAdminGuard } from './seguridad/es-admin.guard';
import { LoginComponent } from './seguridad/components/login/login.component';
import { RegistroComponent } from './seguridad/components/registro/registro.component';
import { UsuarioListComponent } from './components/usuario/usuario-list/usuario-list.component';

export const routes: Routes = [
  {path: 'generos', component: GeneroListComponent},
  {path: 'genero/:id', component: GeneroDetailsComponent},
  {path: 'genero/add', component: GeneroPostFormComponent},
  {path: 'genero/edit/:id', component: GeneroPutFormComponent},
  {path: 'actores', component: ActorListComponent},
  {path: 'actor/:id', component: ActorDetailComponent},
  {path: 'actor/add', component: ActorPostFormComponent, canActivate: [esAdminGuard]},
  {path: 'actor/edit/:id', component: ActorPutFormComponent, canActivate: [esAdminGuard]},
  {path: 'usuarios', component: UsuarioListComponent, canActivate: [esAdminGuard]},
  {path: '', redirectTo: 'generos', pathMatch: 'full'},

  // SEGURIDAD 
  {path: 'login', component: LoginComponent},
  {path: 'registro', component: RegistroComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
