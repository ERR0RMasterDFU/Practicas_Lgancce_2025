import { Component, Input, OnInit } from '@angular/core';
import { SeguridadService } from '../seguridad.service';

@Component({
  selector: 'app-autorizado',
  standalone: false,
  templateUrl: './seguridad.component.html',
  styleUrl: './seguridad.component.css'
})
export class SeguridadComponent implements OnInit {

  constructor(private seguridadService: SeguridadService){
  }

  @Input() rol: string | undefined;

  ngOnInit(): void {
  }
  
  estaAutorizado(): boolean {
    if(this.rol) {
      return this.seguridadService.obtenerRol() === this.rol;
    } else {
      return this.seguridadService.estaLogueado();
    }
  }
  
 

}
