export interface GetActorDtoSimple {
    id: number
    nombre: string
    foto: string
}

export interface GetActorDtoCompleto {
    id: number
    nombre: string
    biografia: string
    fechaNacimiento: Date
    foto: string
}

export interface EditActorRequest {
    nombre: string
    biografia: string
    fechaNacimiento: Date
    foto: File | null;
}
