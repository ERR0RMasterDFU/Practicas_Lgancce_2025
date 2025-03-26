import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'capitalize',
  standalone: false
})
export class CapitalizePipe implements PipeTransform {

  transform(nombre: string) {
    return nombre.charAt(0).toUpperCase() + nombre.slice(1).toLowerCase();
  }

}
