import { Component } from '@angular/core';
import { EditActorRequest, GetActorDtoCompleto } from '../../../interfaces/actor.interfaces';
import { ActivatedRoute, Router } from '@angular/router';
import { ActorService } from '../../../services/actor.service';
import { parsearErroresAPI } from '../../../errors/mostrar-errores/utilidades';
import { toBase64, urlToFile } from '../../utilidades';

@Component({
  selector: 'app-actor-put-form',
  standalone: false,
  templateUrl: './actor-put-form.component.html',
  styleUrl: './actor-put-form.component.css'
})
export class ActorPutFormComponent {
  
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private actorService: ActorService
  ) {}

  // ACTOR VACÍO QUE SE RELLENARÁ CON LOS DATOS EDITADOS
  actorEditado: EditActorRequest = {
    nombre: '',
    biografia: '',
    fechaNacimiento: new Date(),
    foto: null
  };

  // ACTOR QUE VAMOS A EDITAR
  actorAEditar: GetActorDtoCompleto | undefined;

  // DATOS RECOGIDOS DEL ACTOR QUE VAMOS A EDITAR
  id: number = 0;
  nombre!: string;
  biografia!: string;
  fechaNacimiento!: Date;
  foto: File = new File([], "");
  fotoString: string | null | undefined;
  imagenSeleccionada: string ="";

  errores: string[] = [];
  
  ngOnInit(): void { 
    const actorId: string | null = this.route.snapshot.paramMap.get('id');

    if (actorId) {
      const actorIdNum = parseInt(actorId);

      this.actorService.getActorById(actorIdNum).subscribe(respuesta => {
        this.actorAEditar = respuesta;
        this.id = actorIdNum
        this.nombre = this.actorAEditar.nombre
        this.biografia = this.actorAEditar.biografia;
        this.fechaNacimiento = this.actorAEditar.fechaNacimiento;
        this.fotoString = this.actorAEditar.foto;
      });
    }
  }

  editarActor(): void {
    console.log(this.crearEditActorRequest())
    this.actorService.editarActor(this.id, this.crearEditActorRequest()).subscribe(
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
    this.actorEditado.nombre = this.nombre.trim();
    this.actorEditado.biografia = this.biografia.trim();
    this.actorEditado.fechaNacimiento = this.fechaNacimiento;
    //this.actorEditado.foto = this.foto;

    if (this.foto === null || this.foto.size === 0) {
      console.log("foto nula")
      this.actorEditado.foto = null;  // Indicar que no hay foto
      console.log(this.actorEditado.foto)
    } else {
      this.actorEditado.foto = this.foto;
    }

    return this.actorEditado;
  }

  // Este método se ejecuta cuando el archivo es seleccionado
    onFileSelected(event: any): void {
      const fileInput = event.target;
      //event.target!.files[0];
      if (fileInput && fileInput.files && fileInput.files[0]) {
        this.foto =  fileInput.files[0];
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

    eliminarNuevaFoto(): void {
      this.foto = new File([], "");
      this.imagenSeleccionada = '';
    }

    eliminarFotoActual(): void {
      this.foto = new File([], "");
      this.imagenSeleccionada = '';
      this.fotoString = null;
    }

    deshabilitarBoton(): boolean {
      return !this.nombre?.trim();
    }
}