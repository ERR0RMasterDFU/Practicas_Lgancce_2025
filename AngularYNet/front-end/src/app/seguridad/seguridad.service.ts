import { Injectable } from '@angular/core';
import { AutenticationResponse, CredencialesUsuario } from './seguridad.interfaces';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService {

  constructor(private httpClient: HttpClient) { }

  apiUrl = environment.apiBaseUrl + 'cuentas'
  private readonly tokenKey = 'token';
  private readonly tokenExpiracionKey = 'token_espiracion';

  estaLogueado(): boolean{

    const token = localStorage.getItem(this.tokenKey)

    if(!token){
      return false;
    }

    const expiracion = localStorage.getItem(this.tokenExpiracionKey);
    const expiracionFecha = new Date(expiracion!);

    if(expiracionFecha <= new Date()){
      this.logout();
      return false;
    }

    return true;
  }

  logout(){
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.tokenExpiracionKey);
  }

  obtenerRol(): string {
    return "";
  }

  obtenerCampoJWT(campo: string): string{
    const token = localStorage.getItem(this.tokenKey);
    if(!token){return '';}
    var dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[campo];
  }

  registrar(credenciales: CredencialesUsuario): Observable<AutenticationResponse> {
    return this.httpClient.post<AutenticationResponse>(this.apiUrl + '/crear', credenciales);
  }

  login(credenciales: CredencialesUsuario): Observable<AutenticationResponse> {
    return this.httpClient.post<AutenticationResponse>(this.apiUrl + '/login', credenciales);
  }

  guardarToken(autenticationResponse: AutenticationResponse){
    localStorage.setItem(this.tokenKey, autenticationResponse.token);
    localStorage.setItem(this.tokenExpiracionKey, autenticationResponse.expiracion.toString());
  }

}
