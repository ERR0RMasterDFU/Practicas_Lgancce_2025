import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-mostrar-errores',
  standalone: false,
  templateUrl: './mostrar-errores.component.html',
  styleUrl: './mostrar-errores.component.css'
})
export class MostrarErroresComponent {
  
  @Input()
  errores: string [] = [];

}
