import { Component, Input, OnInit } from '@angular/core';
import { SeguridadService } from '../../seguridad.service';
import { CredencialesUsuario } from '../../seguridad.interfaces';
import { parsearErroresAPI } from '../../../errors/mostrar-errores/utilidades';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registro',
  standalone: false,
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent implements OnInit {

  constructor(private seguridadService: SeguridadService, private router: Router) {}  


  // VARIABLES --------------------------------------------------------------------------------------------------

  @Input() errores: string[] = [];

  credenciales: CredencialesUsuario = {
    email: "",
    password: ""
  }

  email: string = "";
  password: string = "";
  campoEmail = document.getElementById('credentialEmail');
  campoPassword = document.getElementById('credentialPassword');

  // MÉTODOS ----------------------------------------------------------------------------------------------------

  ngOnInit(): void {
  }

  registrar(): void {
    console.log(this.crearCredenciales())
    this.seguridadService.registrar(this.crearCredenciales()).subscribe(
      (resp) => {
        this.seguridadService.guardarToken(resp);
        this.router.navigate(['/login']);
      },
      (error) => {
        this.errores = parsearErroresAPI(error);
        //console.error('Error al crear el género:', error);
      }
    );
  }

  crearCredenciales() {
    this.credenciales.email = this.email;
    this.credenciales.password = this.password;

    return this.credenciales;
  }

  deshabilitarBoton(): boolean {
    return !this.email?.trim() || !this.password?.trim();
  }


  // CÓDIGO DEL TÍO DEL VÍDEO ----------------------------------------------------------------------------------------------------------

  /*
  constructor(private formBuilder: FormBuilder) {}  

  form: FormGroup | undefined;

  @Output()
  onSubmit: EventEmitter<CredencialesUsuario> = new EventEmitter<CredencialesUsuario>

  ngOnInit(): void {
    /*this.form = this.formBuilder.group({
      email: ['', {
        validators: [Validators.required, Validators.email]
      }],
      password: ['', {
        validators: [Validators.required]
      }]
    })
  }*/

  // -----------------------------------------------------------------------------------------------------------------------------------

}