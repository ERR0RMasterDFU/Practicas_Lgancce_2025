export interface GetActorDtoSimple {
    id: number
    nombre: string
    foto: string
}

export interface EditActorRequest {
    nombre: string
    biografia: string
    fechaNacimiento: Date
    foto: File;
}
