export function parsearErroresAPI(response: any): string[] {
    const resultado: string [] = [];

    if(response.error){
        if(typeof response.error === 'string'){
            resultado.push(response.error);
        } else{
            const mapaErrores = response.error.errors;
            const entradas = Object.entries(mapaErrores);
            entradas.forEach((array: any[]) => {
                const campo = array[0];
                array[1].forEach((mensajeError: any) => {
                    resultado.push(`${campo}: ${mensajeError}`);
                });
            })
        }
    }
    return resultado;
}