import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GeneroService } from '../../../services/genero.service';
import { GeneroResponse } from '../../../interfaces/genero.interfaces';

@Component({
  selector: 'app-genero-put-form',
  standalone: false,
  templateUrl: './genero-put-form.component.html',
  styleUrl: './genero-put-form.component.css'
})
export class GeneroPutFormComponent implements OnInit {
  
  constructor(
    private router: Router,
    private generoService: GeneroService,
    private route: ActivatedRoute
  ) {}

  id: number = 0;
  nombre: string = "";

  generoId: string | null = "";
  genero: GeneroResponse | undefined;


  ngOnInit(): void { 
    this.generoId = this.route.snapshot.paramMap.get('id');

    if (this.generoId) {
      const generoIdNum = parseInt(this.generoId);

      this.generoService.getGeneroById(generoIdNum).subscribe(respuesta => {
        this.genero = respuesta;
        this.nombre = this.genero.nombre
        this.id = generoIdNum
      });
    }
  }

  editarGenero(): void {
    //console.log(this.capitalizarPalabra(this.nombre).trim())
    this.generoService.editarGenero(this.capitalizarPalabra(this.nombre).trim(), this.id).subscribe(
      (resp) => {
        this.router.navigate(["/generos"]);
      },
      (error) => {
        console.error('Error al editar el género:', error);
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
