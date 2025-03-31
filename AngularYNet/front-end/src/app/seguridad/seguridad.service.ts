import { Injectable } from '@angular/core';
import { AutenticationResponse, CredencialesUsuario, usuarioResponse } from './seguridad.interfaces';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService {

  constructor(private httpClient: HttpClient) { }

  apiUrl = environment.apiBaseUrl + 'cuentas'
  private readonly tokenKey = 'token';
  private readonly tokenExpiracionKey = 'token_espiracion';
  private readonly campoRole = 'role';

  obtenerUsuarios(pagina: number, recordsPorPagina: number): Observable<any>{
    let params = new HttpParams();
    params = params.append('pagina', pagina.toString());
    params = params.append('recordsPorPagina', recordsPorPagina.toString());
    return this.httpClient.get<usuarioResponse[]>(`${this.apiUrl}/listadoUsuarios`,
      {observe: 'response', params}
    )
  }

  addAdmin(usuarioId: number) {
    const headers = new HttpHeaders('Content-Type: application/json');
    return this.httpClient.post(`${this.apiUrl}/addAdmin`, JSON.stringify(usuarioId), {headers});
  }

  removeAdmin(usuarioId: number) {
    const headers = new HttpHeaders('Content-Type: application/json');
    return this.httpClient.post(`${this.apiUrl}/removeAdmin`, JSON.stringify(usuarioId), {headers});
  }

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
    return this.obtenerCampoJWT(this.campoRole);
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
