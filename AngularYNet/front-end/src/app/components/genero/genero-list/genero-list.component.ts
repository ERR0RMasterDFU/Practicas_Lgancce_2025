import { Component } from '@angular/core';
import { GeneroService } from '../../../services/genero.service';
import { GeneroResponse } from '../../../interfaces/genero.interfaces';
import { HttpResponse } from '@angular/common/http';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-genero-list',
  standalone: false,
  templateUrl: './genero-list.component.html',
  styleUrl: './genero-list.component.css'
})
export class GeneroListComponent {

  /* MODAL
  id: number = 0;
  nombre: string | undefined;
  modal: any;*/

  listaGeneros: GeneroResponse[] | null = [];
  columnasAMostrar = ['id', 'nombre', 'acciones'];
  cantidadTotalElementos: string | null | undefined;
  paginaActual = 1;
  elementosAMostrar = 16;

  
  constructor(private generoService: GeneroService, private router: Router, private modalService: NgbModal  ) { }


  ngOnInit(): void {
    this.cargarGeneros(this.paginaActual, this.elementosAMostrar);
  }

  cargarGeneros(pagina: number, elementosAMostrar: number): void {
    this.generoService.getAllGeneros(pagina, elementosAMostrar).subscribe(
      // (response) => { this.listaGeneros = response; }
      (respuesta: HttpResponse<GeneroResponse[]>) => {
        this.listaGeneros = respuesta.body;
        console.log(respuesta.headers.get("cantidadTotalRegistros"));
        this.cantidadTotalElementos = respuesta.headers.get("cantidadTotalRegistros");
      },
      (error) => {
        console.error("Error al cargar géneros", error);
      }
    );
  }

  actualizarPaginacion(datos: PageEvent) {
    this.paginaActual = datos.pageIndex + 1;
    this.elementosAMostrar = datos.pageSize;
    this.cargarGeneros(this.paginaActual, this.elementosAMostrar);
  }

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
  }

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
