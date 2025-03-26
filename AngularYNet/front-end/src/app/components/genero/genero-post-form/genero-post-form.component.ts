import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { GeneroService } from '../../../services/genero.service';
import { parsearErroresAPI } from '../../../errors/mostrar-errores/utilidades';

@Component({
  selector: 'app-genero-post-form',
  standalone: false,
  templateUrl: './genero-post-form.component.html',
  styleUrl: './genero-post-form.component.css'
})
export class GeneroPostFormComponent {
  
  constructor(
    private router: Router,
    private generoService: GeneroService
  ) {}

  
  nombre: string = "";
  errores: string[] = [];
  

  crearGenero(): void {
    //console.log(this.capitalizarPalabra(this.nombre).trim())
    this.generoService.crearGenero(this.capitalizarPalabra(this.nombre).trim()).subscribe(
      (resp) => {
        this.router.navigate(["/generos"]);
      },
      (error) => {
        this.errores = parsearErroresAPI(error);
        //console.error('Error al crear el género:', error);
      }
    );
  }

  deshabilitarBoton(): boolean {
    return !this.nombre?.trim();
  }

  capitalizarPalabra(nombre: string){
    return nombre.charAt(0).toUpperCase() + nombre.slice(1);
  }

}