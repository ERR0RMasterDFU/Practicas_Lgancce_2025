import { Component } from '@angular/core';
import { usuarioResponse } from '../../../seguridad/seguridad.interfaces';
import { SeguridadService } from '../../../seguridad/seguridad.service';
import { HttpResponse } from '@angular/common/http';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuario-list',
  standalone: false,
  templateUrl: './usuario-list.component.html',
  styleUrl: './usuario-list.component.css'
})
export class UsuarioListComponent {

  listaUsuarios: usuarioResponse[] | null = [];
  columnasAMostrar = ['id', 'nombre', 'acciones'];
  cantidadTotalElementos: string | null | undefined;
  paginaActual = 1;
  elementosAMostrar = 16;

  
  constructor(public seguridadService: SeguridadService, private router: Router) { }


  ngOnInit(): void {
    this.cargarUsuarios(this.paginaActual, this.elementosAMostrar);
  }

  cargarUsuarios(pagina: number, elementosAMostrar: number): void {
    this.seguridadService.obtenerUsuarios(pagina, elementosAMostrar).subscribe(
      (respuesta: HttpResponse<usuarioResponse[]>) => {
        this.listaUsuarios = respuesta.body;
        console.log(respuesta.headers.get("cantidadTotalRegistros"));
        this.cantidadTotalElementos = respuesta.headers.get("cantidadTotalRegistros");
      },
      (error) => {
        console.error("Error al cargar los usuarios", error);
      }
    );
  }

  actualizarPaginacion(datos: PageEvent) {
    this.paginaActual = datos.pageIndex + 1;
    this.elementosAMostrar = datos.pageSize;
    this.cargarUsuarios(this.paginaActual, this.elementosAMostrar);
  }


/*
  eliminarGenero(id: number): void {
    console.log(id);
    this.generoService.eliminarGenero(id).subscribe(
      (resp) => {
        //modal.close();  // Cerrar el modal después de la eliminación
        this.router.navigate(["/generos"]);
      },
      (error) => {
        console.error('Error al eliminar género:', error);
      }
    );
  }*/

  /* MODAL 
  eliminarGenero(): void {
    console.log(this.id);
    this.generoService.eliminarGenero(this.id).subscribe(
      (resp) => {
        //modal.close();  // Cerrar el modal después de la eliminación
        this.router.navigate(["/generos"]);
      },
      (error) => {
        console.error('Error al eliminar género:', error);
      }
    );
  }


  extraerDatosAModal(idGen: number, nombreGen: string, event: MouseEvent): void {
    this.id = idGen;
    this.nombre = nombreGen;
    event.stopPropagation();  // Esto evita que el clic se propague y active el routerLink
  }*/
  
}
