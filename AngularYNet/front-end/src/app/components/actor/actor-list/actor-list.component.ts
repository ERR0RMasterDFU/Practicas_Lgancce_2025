import { Component } from '@angular/core';
import { GetActorDtoSimple } from '../../../interfaces/actor.interfaces';
import { ActorService } from '../../../services/actor.service';
import { Router } from '@angular/router';
import { HttpResponse } from '@angular/common/http';
import { PageEvent } from '@angular/material/paginator';
import { SeguridadService } from '../../../seguridad/seguridad.service';

@Component({
  selector: 'app-actor-list',
  standalone: false,
  templateUrl: './actor-list.component.html',
  styleUrl: './actor-list.component.css'
})
export class ActorListComponent {

  listaActores: GetActorDtoSimple[] | null = [];
  cantidadTotalElementos: string | null | undefined;
  paginaActual = 1;
  elementosAMostrar = 16;

  
  constructor(private actorService: ActorService, public seguridadService: SeguridadService, private router: Router) { }


  ngOnInit(): void {
    this.cargarActores(this.paginaActual, this.elementosAMostrar);
  }

  cargarActores(pagina: number, elementosAMostrar: number): void {
    this.actorService.getAllActores(pagina, elementosAMostrar).subscribe(
      (respuesta: HttpResponse<GetActorDtoSimple[]>) => {
        this.listaActores = respuesta.body;
        console.log(respuesta.headers.get("cantidadTotalRegistros"));
        this.cantidadTotalElementos = respuesta.headers.get("cantidadTotalRegistros");
      },
      (error) => {
        console.error("Error al cargar actores", error);
      }
    );
  }

  actualizarPaginacion(datos: PageEvent) {
    this.paginaActual = datos.pageIndex + 1;
    this.elementosAMostrar = datos.pageSize;
    this.cargarActores(this.paginaActual, this.elementosAMostrar);
  }

  eliminarActores(id: number): void {
    console.log(id);
    this.actorService.eliminarActor(id).subscribe(
      (resp) => {
        this.cargarActores(this.paginaActual, this.elementosAMostrar);
      },
      (error) => {
        console.error('Error al eliminar el actor:', error);
      }
    );
  }
}
