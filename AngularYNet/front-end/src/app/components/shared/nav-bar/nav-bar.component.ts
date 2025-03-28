import { Component } from '@angular/core';
import { SeguridadService } from '../../../seguridad/seguridad.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  standalone: false,
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {

  constructor(public seguridadService: SeguridadService, private router: Router) {}  


  ngOnInit(): void {
    }
  
    logout(): void {
      this.seguridadService.logout();
    }

}
