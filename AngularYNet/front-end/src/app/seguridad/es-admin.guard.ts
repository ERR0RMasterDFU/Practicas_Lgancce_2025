import { CanActivateFn, Router } from '@angular/router';
import { SeguridadService } from './seguridad.service';
import { inject } from '@angular/core';


export const esAdminGuard: CanActivateFn = (route, state) => {
  const seguridadService = inject(SeguridadService);
  const router = inject(Router)

  if (seguridadService.obtenerRol() === 'admin') {
    return true;
  } 

  router.navigate(['/login']);
    return false;
};
