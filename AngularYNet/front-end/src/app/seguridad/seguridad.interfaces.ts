export interface CredencialesUsuario {
    email: string
    password: string
}

export interface AutenticationResponse {
    token: string;
    expiracion: Date;
}

export interface usuarioResponse {
    id: number;
    email: string;
}

export interface EditActorRequest {
    nombre: string
    biografia: string
    fechaNacimiento: Date
    foto: File | null;
}