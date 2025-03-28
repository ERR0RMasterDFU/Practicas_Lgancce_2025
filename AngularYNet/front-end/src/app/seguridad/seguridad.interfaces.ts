export interface CredencialesUsuario {
    email: string
    password: string
}

export interface AutenticationResponse {
    token: string;
    expiracion: Date;
}

export interface EditActorRequest {
    nombre: string
    biografia: string
    fechaNacimiento: Date
    foto: File | null;
}