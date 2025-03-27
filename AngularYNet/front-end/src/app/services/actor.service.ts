import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { EditActorRequest, GetActorDtoCompleto, GetActorDtoSimple } from '../interfaces/actor.interfaces';

@Injectable({
  providedIn: 'root'
})
export class ActorService {

  constructor(private http: HttpClient) {}

  private apiUrl = environment.apiBaseUrl + "actor"

  getAllActores(pagina: number, elementosAMostrar: number): Observable<any>{
    let params = new HttpParams();
    params = params.append('pagina', pagina.toString());
    params = params.append('elementosPorPagina', elementosAMostrar.toString());
    return this.http.get<GetActorDtoSimple[]>(this.apiUrl, {observe: 'response', params});
  }

  getActorById(id: number): Observable<GetActorDtoCompleto> {
    const url = this.apiUrl + "/" + id;
    return this.http.get<GetActorDtoCompleto>(url);
  }

  crearActor(actor: EditActorRequest) {
    const formData = this.construirFormData(actor);
    return this.http.post(this.apiUrl, formData);
  }

  editarActor(id:number, actor: EditActorRequest) {
    const url = this.apiUrl + "/" + id;
    const formData = this.construirFormData(actor);
    return this.http.put(url, formData);
  }

  eliminarActor(id: number) {
    const url = this.apiUrl + "/" + id;
    return this.http.delete(url);
  }


  // MÉTODOS AUXILIARES ----------------------------------------------------------------------------------

  private construirFormData(actor: EditActorRequest): FormData {
    const formData = new FormData();
    formData.append('nombre', actor.nombre);
    
    if(actor.biografia){
      formData.append('biografia', actor.biografia);
    }
  
    if(actor.fechaNacimiento){
      const fecha = new Date(actor.fechaNacimiento);  // Convierte a Date si es necesario
      formData.append('fechaNacimiento', this.formatearFecha(fecha));
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
  private formatearFecha(fecha: Date): Date {
    const dia = String(fecha.getDate()).padStart(2, '0');       // DÍA CON 2 DÍGITOS
    const mes = String(fecha.getMonth() + 1).padStart(2, '0');  // MES CON 2 DÍGITOS
    const anio = fecha.getFullYear();                           // AÑO CON 4 DÍGITOS
    
    // FORMATEAMOS LA FECHA PARA CREAR EL DATE (ISO 8601: "YYYY-MM-DD")
    const fechaFormateada = `${anio}-${mes}-${dia}`;

    return new Date(fechaFormateada);
  }*/

  // -----------------------------------------------------------------------------------------------------

}
