import { Component, Input } from '@angular/core';
import { GeneroResponse } from '../../../interfaces/genero.interfaces';
import { GeneroService } from '../../../services/genero.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-genero-card',
  standalone: false,
  templateUrl: './genero-card.component.html',
  styleUrl: './genero-card.component.css'
})
export class GeneroCardComponent {

  @Input() generoId: GeneroResponse | undefined;


  constructor(
    private generoService: GeneroService,
    private router: Router
  ) {}


  eliminarGenero(): void {
    this.generoService.eliminarGenero(this.generoId!.id).subscribe(
      (resp) => {
        this.router.navigate(["/generos"]);
      },
      (error) => {
        console.error('Error al eliminar género:', error);
      }
    );
  }

  onDeleteClick(event: MouseEvent) {
    event.stopPropagation();  // Esto evita que el clic se propague y active el routerLink
  }

}
