import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { GeneroResponse } from '../interfaces/genero.interfaces';

@Injectable({
  providedIn: 'root'
})
export class GeneroService {

  constructor(private http: HttpClient) {}

  private apiUrl = environment.apiBaseUrl + "genero"

  // getAllGeneros(): Observable<GeneroResponse[]>{
  getAllGeneros(pagina: number, elementosAMostrar: number): Observable<any>{
    let params = new HttpParams();
    params = params.append('pagina', pagina.toString());
    params = params.append('elementosPorPagina', elementosAMostrar.toString());
    return this.http.get<GeneroResponse[]>(this.apiUrl, {observe: 'response', params});
  }

  getGeneroById(id: number): Observable<GeneroResponse> {
    const url = this.apiUrl + "/" + id;
    return this.http.get<GeneroResponse>(url);
  }

  crearGenero(nombre: string) {
    const body = {
      nombre: nombre
    };
    return this.http.post(this.apiUrl, body);
  }

  editarGenero(nombre: string, id: number) {
    const url = this.apiUrl + "/" + id;
    const body = {
      nombre: nombre
    };
    return this.http.put(url, body);
  }

  eliminarGenero(id: number) {
    const url = this.apiUrl + "/" + id;
    return this.http.delete(url);
  }

}
