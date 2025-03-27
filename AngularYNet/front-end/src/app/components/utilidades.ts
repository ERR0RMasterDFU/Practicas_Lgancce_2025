export function toBase64(file: File){
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result);
        reader.onerror = (error) => reject(error);
    })
}

// CONVIERTE UN STRING EN FOTO DE NUEVO
// URL DE EJEMPLO: fotoString = 'https://example.com/image.jpg'
export async function urlToFile(fotoString: string): Promise<File> {
    const url = fotoString;                                                 // COGE LA URL INTRODUCIDA COMO ARGUMENTO
    const filename = fotoString.split('/').pop()!;                          // DIVIDE EL STRING POR / Y COGE EL ÚLTIMO SEGMENTO: "nombreImagen.extensión"
    const mimeType = "image/" + filename.split('.').pop()?.toLowerCase();   // DIVIDE EL STRING POR . Y COGE EL ÚLTIMO SEGMENTO: "extensión"

    const response = await fetch(url);
    const blob = await response.blob();
    return new File([blob], filename, { type: mimeType });
}