import { Component } from '@angular/core';
import { parsearErroresAPI } from '../../../errors/mostrar-errores/utilidades';
import { Router } from '@angular/router';
import { ActorService } from '../../../services/actor.service';
import { EditActorRequest } from '../../../interfaces/actor.interfaces';
import { toBase64 } from '../../utilidades';

@Component({
  selector: 'app-actor-post-form',
  standalone: false,
  templateUrl: './actor-post-form.component.html',
  styleUrl: './actor-post-form.component.css'
})
export class ActorPostFormComponent {
  
  constructor(
    private router: Router,
    private actorService: ActorService
  ) {}

  
  nuevoActor: EditActorRequest = {
    nombre: '',
    biografia: '',
    fechaNacimiento: new Date(),
    foto: null
  };

  nombre!: string;
  biografia!: string;
  fechaNacimiento!: Date;
  foto: File = new File([], "");
  imagenSeleccionada: string ="";

  errores: string[] = [];
  

  crearActor(): void {
    this.actorService.crearActor(this.crearEditActorRequest()).subscribe(
      (resp) => {
        console.log(this.crearEditActorRequest())
        this.router.navigate(["/actores"]);
      },
      (error) => {
        this.errores = parsearErroresAPI(error);
        //console.error('Error al crear el género:', error);
      }
    );
  }

  crearEditActorRequest(): EditActorRequest {
    this.nuevoActor.nombre = this.nombre.trim();
    this.nuevoActor.biografia = this.biografia.trim();
    this.nuevoActor.fechaNacimiento = this.fechaNacimiento;
    this.nuevoActor.foto = this.foto;

    return this.nuevoActor;
  }

  obtenerFoto(){

  }

  deshabilitarBoton(): boolean {
    return !this.nombre?.trim();
  }

  capitalizarPalabra(nombre: string){
    return nombre.charAt(0).toUpperCase() + nombre.slice(1);
  }

  // Este método se ejecuta cuando el archivo es seleccionado
  onFileSelected(event: any): void {
    const file = event.target!.files[0];
    if (file) {
      this.foto = file;
      toBase64(this.foto).then((value: any) => this.imagenSeleccionada = value);
      console.log('Archivo seleccionado:', this.foto); // Mostramos los datos del archivo
      console.log('Nombre del archivo:', this.foto.name);
      console.log('Tipo de archivo:', this.foto.type);
      console.log('Tamaño del archivo:', this.foto.size);
    } else {
      this.foto = new File([], "");
      this.imagenSeleccionada = ''; 
    }
  }

}