import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app.component';
import { GeneroCardComponent } from './components/genero/genero-card/genero-card.component';
import { GeneroListComponent } from './components/genero/genero-list/genero-list.component';
import { MaterialModule } from '../modules/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './components/shared/nav-bar/nav-bar.component';
import { GeneroPostFormComponent } from './components/genero/genero-post-form/genero-post-form.component';
import { CapitalizePipe } from './pipes/capitalize.pipe';
import { GeneroDetailsComponent } from './components/genero/genero-details/genero-details.component';
import { GeneroPutFormComponent } from './components/genero/genero-put-form/genero-put-form.component';
import { MostrarErroresComponent } from './errors/mostrar-errores/mostrar-errores.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ActorCardComponent } from './components/actor/actor-card/actor-card.component';
import { ActorListComponent } from './components/actor/actor-list/actor-list.component';
import { ActorPostFormComponent } from './components/actor/actor-post-form/actor-post-form.component';
import { ActorDetailComponent } from './components/actor/actor-detail/actor-detail.component';
import { ActorPutFormComponent } from './components/actor/actor-put-form/actor-put-form.component';
import { SeguridadComponent } from './seguridad/seguridad/seguridad.component';
import { LoginComponent } from './seguridad/components/login/login.component';
import { RegistroComponent } from './seguridad/components/registro/registro.component';
import { UsuarioListComponent } from './components/usuario/usuario-list/usuario-list.component';
//import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

@NgModule({
  declarations: [
    AppComponent,
    GeneroCardComponent,
    GeneroListComponent,
    NavBarComponent,
    GeneroPostFormComponent,
    CapitalizePipe,
    GeneroDetailsComponent,
    GeneroPutFormComponent,
    MostrarErroresComponent,
    ActorCardComponent,
    ActorListComponent,
    ActorPostFormComponent,
    ActorDetailComponent,
    ActorPutFormComponent,
    SeguridadComponent,
    LoginComponent,
    RegistroComponent,
    UsuarioListComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    MatPaginatorModule,
    //SweetAlert2Module.forRoot(),
  ],
  providers: [
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
