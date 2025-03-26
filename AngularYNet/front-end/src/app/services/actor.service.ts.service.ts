import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { EditActorRequest, GetActorDtoSimple } from '../interfaces/actor.interfaces';

@Injectable({
  providedIn: 'root'
})
export class ActorServiceTsService {

  constructor(private http: HttpClient) {}

  private apiUrl = environment.apiBaseUrl + "actor"

  getAllActores(pagina: number, elementosAMostrar: number): Observable<any>{
    let params = new HttpParams();
    params = params.append('pagina', pagina.toString());
    params = params.append('elementosPorPagina', elementosAMostrar.toString());
    return this.http.get<GetActorDtoSimple[]>(this.apiUrl, {observe: 'response', params});
  }
/*
  getGeneroById(id: number): Observable<GeneroResponse> {
    const url = this.apiUrl + "/" + id;
    return this.http.get<GeneroResponse>(url);
  }*/

  crearGenero(actor: EditActorRequest) {
    const formData = this.construirFormData(actor);
    return this.http.post(this.apiUrl, formData);
  }

  private construirFormData(actor: EditActorRequest): FormData {
    const formData = new FormData();
    formData.append('nombre', actor.nombre);
    
    if(actor.biografia){
      formData.append('biografia', actor.biografia);
    }
  
    if(actor.fechaNacimiento){
      formData.append('fechaNacimiento', this.formatearFecha(actor.fechaNacimiento));
    }

    if(actor.foto){
      formData.append('foto', actor.foto);
    }
    
    return formData;
  }

  private formatearFecha(fecha: Date): string {
    const dia = String(fecha.getDate()).padStart(2, '0'); // DÍA CON 2 DÍGITOS
    const mes = String(fecha.getMonth() + 1).padStart(2, '0'); // MES CON 2 DÍSGITOS
    const anio = fecha.getFullYear(); // AÑO CON 4 DÍGITOS
    
    return `${dia}/${mes}/${anio}`;
  }

/*
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
  }*/

}
