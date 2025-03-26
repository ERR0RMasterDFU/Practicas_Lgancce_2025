using PeliculasApi.DTOs.Actor;
using PeliculasApi.Modelos;
using System;
using System.Linq;

namespace PeliculasApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Comprueba si ya existen datos
            if (context.Genero.Any())
            {
                return;
            }

            // Comprueba si ya existen datos
            if (context.Actor.Any())
            {
                return;
            }


            // GÉNEROS -------------------------------------------------------------------------------------------------------

            var generos = new Genero[]
            {
                new Genero { nombre = "Comedia" },
                new Genero { nombre = "Drama" },
                new Genero { nombre = "Acción" },
                new Genero { nombre = "Ciencia ficción" },
                new Genero { nombre = "Aventura" },
                new Genero { nombre = "Terror" },
                new Genero { nombre = "Romántico" },
                new Genero { nombre = "Thriller" },
                new Genero { nombre = "Suspenso" },
                new Genero { nombre = "Fantasía" },
                new Genero { nombre = "Misterio" },
                new Genero { nombre = "Animación" },
                new Genero { nombre = "Documental" },
                new Genero { nombre = "Biográfico" },
                new Genero { nombre = "Musical" },
                new Genero { nombre = "Histórico" },
                new Genero { nombre = "Western" },
                new Genero { nombre = "Deportivo" },
                new Genero { nombre = "Bélico" },
                new Genero { nombre = "Familia" },
                new Genero { nombre = "Cultura" },
                new Genero { nombre = "Ficción histórica" },
                new Genero { nombre = "Superhéroes" },
                new Genero { nombre = "Artes marciales" },
                new Genero { nombre = "Parodia" },
                new Genero { nombre = "Cine independiente" },
                new Genero { nombre = "Ciencia" },
                new Genero { nombre = "Romántica histórica" },
                new Genero { nombre = "Guerra" },
                new Genero { nombre = "Infantil" },
                new Genero { nombre = "Época medieval" },
                new Genero { nombre = "Steampunk" },
                new Genero { nombre = "Cyberpunk" },
                new Genero { nombre = "Manga" },
                new Genero { nombre = "Esotérico" },
                new Genero { nombre = "Lucha libre" },
                new Genero { nombre = "Comedia dramática" },
                new Genero { nombre = "Cine negro" },
                new Genero { nombre = "Aventura épica" },
                new Genero { nombre = "Zombis" },
                new Genero { nombre = "Vampiros" },
                new Genero { nombre = "Comedia romántica" },
                new Genero { nombre = "Dystopía" },
                new Genero { nombre = "Surrealista" },
                new Genero { nombre = "Psicológico" },
                new Genero { nombre = "Thriller psicológico" },
                new Genero { nombre = "Antología" }
            };

            context.Genero.AddRange(generos);

            // ---------------------------------------------------------------------------------------------------------------


            // ACTORES -------------------------------------------------------------------------------------------------------

            var actores = new Actor[]
            {
                new Actor
                {
                    Nombre = "Monkey D. Luffy",
                    Biografia = "Luffy es el capitán de los Piratas de Sombrero de Paja. Su sueño es encontrar el One Piece y " +
                    "convertirse en el Rey de los Piratas. Luffy posee una fuerza extraordinaria y la habilidad de estirarse " +
                    "como goma, gracias a haber comido la fruta del diablo Gomu Gomu no Mi (Hito Hito no Mi Modelo Nika).",
                    FechaNacimiento = new DateTime(1999, 5, 5),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Roronoa Zoro",
                    Biografia = "Zoro es el espadachín de los Piratas de Sombrero de Paja. Es un experto en el estilo de tres " +
                    "espadas y su objetivo es convertirse en el mejor espadachín del mundo, un sueño que persigue para honrar " +
                    "la memoria de su amiga Kuina.",
                    FechaNacimiento = new DateTime(1998, 11, 11),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Nami",
                    Biografia = "Nami es la navegante de los Piratas de Sombrero de Paja. Es una ladrona hábil y posee un vasto " +
                    "conocimiento sobre mapas y navegación. Su sueño es crear un mapa del mundo completo.",
                    FechaNacimiento = new DateTime(1997, 7, 3),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Usopp",
                    Biografia = "Usopp es el francotirador de los Piratas de Sombrero de Paja. Es conocido por su habilidad para " +
                    "mentir y sus historias fantásticas, pero a pesar de su naturaleza miedosa, demuestra gran valentía en las " +
                    "batallas. Su sueño es convertirse en un valiente guerrero del mar.",
                    FechaNacimiento = new DateTime(1999, 4, 1),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Sanji",
                    Biografia = "Sanji es el cocinero de los Piratas de Sombrero de Paja. Aparte de su habilidad en la cocina, es " +
                    "un luchador excepcional que utiliza sus piernas para combatir. Su sueño es encontrar el All Blue, un mar " +
                    "legendario donde todos los mares del mundo se encuentran.",
                    FechaNacimiento = new DateTime(1995, 3, 2),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Tony Tony Chopper",
                    Biografia = "Chopper es el médico de los Piratas de Sombrero de Paja. Es un reno que comió la Hito Hito no Mi, " +
                    "permitiéndole transformarse en diferentes formas humanas. Su sueño es convertirse en un gran médico que pueda " +
                    "curar cualquier enfermedad.",
                    FechaNacimiento = new DateTime(1998, 12, 24),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Nico Robin",
                    Biografia = "Robin es la arqueóloga de los Piratas de Sombrero de Paja. Tiene la habilidad de hacer aparecer " +
                    "partes de su cuerpo en cualquier lugar, gracias a los poderes de la Hana Hana no Mi. Su sueño es encontrar " +
                    "el Rio Poneglyph y desvelar la historia prohibida del siglo vacío.",
                    FechaNacimiento = new DateTime(1997, 2, 6),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Franky (Cutty Flam)",
                    Biografia = "Franky es el carpintero de los Piratas de Sombrero de Paja. Es un cyborg con habilidades mecánicas " +
                    "excepcionales, y su sueño es construir el mejor barco del mundo, el Thousand Sunny.",
                    FechaNacimiento = new DateTime(1994, 6, 9),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Brook",
                    Biografia = "Brook es el músico de los Piratas de Sombrero de Paja. Es un esqueleto viviente que comió la Yomi " +
                    "Yomi no Mi, lo que le permitió regresar a la vida. Su sueño es reunirse con su viejo amigo Laboon, una ballena " +
                    "gigante.",
                    FechaNacimiento = new DateTime(1991, 4, 12),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Jinbe",
                    Biografia = "Jinbe es el timonel de los Piratas de Sombrero de Paja. Es un hombre pez y antiguo miembro de los " +
                    "Piratas de los Siete Guerreros del Mar. Su sueño es promover la paz entre los humanos y los hombres pez.",
                    FechaNacimiento = new DateTime(1988, 1, 15),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Portgas D. Ace",
                    Biografia = "Ace es el hermano adoptivo de Luffy y el antiguo comandante de la Segunda División de los Piratas " +
                    "de Barbablanca. Su sueño era encontrar su propio camino como pirata y proteger a su hermano Luffy.",
                    FechaNacimiento = new DateTime(1995, 6, 1),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Shanks Figarland",
                    Biografia = "Shanks es el capitán de los Piratas del Pelirrojo. Fue una gran influencia en la vida de Luffy, " +
                    "al inspirarlo a convertirse en pirata. Shanks es uno de los Cuatro Emperadores del Mar.",
                    FechaNacimiento = new DateTime(1984, 5, 7),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Trafalgar D. Water Law",
                    Biografia = "Law es el capitán de los Piratas Heart. Es conocido por su habilidad para manipular la anatomía " +
                    "humana gracias a su Ope Ope no Mi. Su sueño es descubrir el misterio detrás de la 'D' en su nombre y vengar " +
                    "la muerte de su familia.",
                    FechaNacimiento = new DateTime(1991, 10, 14),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Smoker",
                    Biografia = "Smoker es un Vicealmirante de la Marina y uno de los principales enemigos de Luffy. Tiene la " +
                    "habilidad de convertir su cuerpo en humo, gracias a la fruta del diablo Moku Moku no Mi.",
                    FechaNacimiento = new DateTime(1982, 3, 10),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Nefertari Vivi",
                    Biografia = "Vivi es la princesa de Alabasta y una amiga cercana de los Piratas de Sombrero de Paja. Luchó " +
                    "junto a ellos para derrocar a Crocodile y salvar su país. Su sueño es traer la paz a su nación.",
                    FechaNacimiento = new DateTime(1996, 12, 22),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Bartholomew Kuma",
                    Biografia = "Kuma es el padre de Bonney y un ex miembro de los Siete Guerreros del Mar y un personaje " +
                    "importante en la lucha contra el gobierno mundial. Es conocido por su poder de repeler cualquier cosa, " +
                    "incluso el dolor y las emociones.",
                    FechaNacimiento = new DateTime(1990, 8, 30),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Dracule Mihawk",
                    Biografia = "Mihawk es el mejor espadachín del mundo y miembro de los Siete Guerreros del Mar. Su " +
                    "habilidad con la espada es incomparable y su sueño es continuar siendo el más fuerte.",
                    FechaNacimiento = new DateTime(1980, 11, 15),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Crocodile",
                    Biografia = "Crocodile es un ex miembro de los Siete Guerreros del Mar y líder de la organización " +
                    "Baroque Works. Tiene el poder de la Suna Suna no Mi, que le permite manipular la arena. Su sueño es " +
                    "derrocar al gobierno mundial y tomar el control del mundo.",
                    FechaNacimiento = new DateTime(1985, 4, 4),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Enel",
                    Biografia = "Enel es el autoproclamado Dios de Skypiea. Tiene el poder de la Goro Goro no Mi, que le " +
                    "otorga habilidades eléctricas extraordinarias. Su sueño es conquistar el mundo con su poder y convertirse " +
                    "en el ser supremo.",
                    FechaNacimiento = new DateTime(1990, 9, 15),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Newgate Edward (Barbablanca)",
                    Biografia = "Newgate, conocido como Barbablanca, fue uno de los Cuatro Emperadores del Mar y el capitán de " +
                    "los Piratas de Barbablanca. Fue un hombre de honor con una fuerte lealtad hacia su tripulación, y su sueño " +
                    "era proteger a su familia pirata.",
                    FechaNacimiento = new DateTime(1950, 1, 23),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Sabo",
                    Biografia = "Sabo es el hermano adoptivo de Luffy y Ace, y el segundo al mando de los Revolucionarios. Su " +
                    "sueño es luchar contra el gobierno mundial y lograr la libertad para todos los pueblos del mundo.",
                    FechaNacimiento = new DateTime(1996, 4, 1),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "X Drake",
                    Biografia = "X Drake es un miembro de SWORD, que se hizo pasar por un antiguo Marine que se unió a los " +
                    "piratas como uno de los Supernovas. Tiene la habilidad de la Ryu Ryu no Mi modelo Alosaurio, que le " +
                    "permite transformarse en un dinosaurio. Su objetivo personal es tomar acabar con el gobierno mundial.",
                    FechaNacimiento = new DateTime(1985, 7, 10),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Kizaru (Borsalino)",
                    Biografia = "Kizaru es un Almirante de la Marina, conocido por su increíble velocidad y habilidad con el " +
                    "rayo gracias a la Pika Pika no Mi. Es un hombre indiferente que sigue la doctrina de la justicia absoluta.",
                    FechaNacimiento = new DateTime(1974, 5, 5),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Akainu (Sakazuki)",
                    Biografia = "Akainu es el actual almirante de flota de la Marina, conocido por su extrema dureza y justicia " +
                    "absoluta. Tiene el poder de la Magu Magu no Mi, que le permite controlar la lava.",
                    FechaNacimiento = new DateTime(1960, 12, 12),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Sengoku",
                    Biografia = "Sengoku fue el Almirante de flota al que sustituyó Akainu y una figura importante en la lucha " +
                    "contra los piratas. Es conocido por su habilidad de transformar su cuerpo en un gigantesco Buda gracias a " +
                    "su fruta del diablo.",
                    FechaNacimiento = new DateTime(1958, 4, 6),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Tashigi",
                    Biografia = "Tashigi es la leal compañera de Smoker y una teniente de la Marina especializada en espadas. " +
                    "Su sueño es reunir todas espadas de gran calidad y evitar que caigan en manos equivocadas.",
                    FechaNacimiento = new DateTime(1989, 3, 12),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Rob Lucci",
                    Biografia = "Rob Lucci es un actual miembro del CP0 y antiguo del CP9, además de uno de los principales " +
                    "antagonistas en la saga de Enies Lobby. Es un hombre frío y calculador, con la habilidad de " +
                    "transformarse en un leopardo gracias a la fruta del diablo Zoan, la Neko Neko no Mi modelo Leopardo.",
                    FechaNacimiento = new DateTime(1986, 12, 1),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Boa Hancock",
                    Biografia = "Hancock es la capitana de los Piratas Kuja y una de las Siete Guerreras del Mar. Tiene el " +
                    "poder de la Mero Mero no Mi, que le permite convertir a las personas en piedra con su mirada.",
                    FechaNacimiento = new DateTime(1986, 11, 23),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Magellan",
                    Biografia = "Magellan es el exdirector de Impel Down. Tiene el poder de la Doku Doku no Mi, que le " +
                    "permite generar venenos mortales. Es conocido por su estricta disciplina y su poder destructivo.",
                    FechaNacimiento = new DateTime(1984, 6, 19),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Charlotte Linlin (Big Mom)",
                    Biografia = "Big Mom es una de los Cuatro Emperadores del Mar. Es una mujer monstruosa que posee una " +
                    "increíble fuerza y el poder de la Soru Soru no Mi, que le permite manipular almas. Su sueño es crear " +
                    "un mundo donde todos los pueblos del mar convivan en paz, aunque a menudo usa métodos despiadados.",
                    FechaNacimiento = new DateTime(1957, 5, 12),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Kaido",
                    Biografia = "Kaido es otro de los Cuatro Emperadores del Mar. Es conocido por su deseo de crear un " +
                    "ejército de piratas y su increíble poder destructivo. Es casi inmortal gracias a la fruta del diablo " +
                    "Uo Uo no Mi, modelo Dragón, lo que le otorga la habilidad de transformarse en un dragón gigante.",
                    FechaNacimiento = new DateTime(1975, 8, 21),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Buggy",
                    Biografia = "Buggy es el hermano adoptivo de Shanks y ex compañero de Gol D. Roger, ahora capitán " +
                    "de los Piratas Buggy. Tiene la habilidad de la Bara Bara no Mi, que le permite separar su cuerpo " +
                    "en partes y hacer que floten. Es un personaje cómico y codicioso, pero muy astuto.",
                    FechaNacimiento = new DateTime(1983, 9, 15),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Cavendish",
                    Biografia = "Cavendish es un famoso pirata conocido como el 'Caballero de los Piratas'. Es un " +
                    "espadachín talentoso, aunque su personalidad cambia radicalmente cuando se transforma en su " +
                    "alter ego, Hakuba, una feroz personalidad con un gran deseo de pelea.",
                    FechaNacimiento = new DateTime(1993, 4, 6),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Caterina Devon",
                    Biografia = "Caterina Devon es una de las piratas más temibles que sirven a Barbanegra. Es una " +
                    "usuaria de fruta del diablo, que le permite transformarse en otras personas. Tiene una " +
                    "naturaleza cruel y despiadada.",
                    FechaNacimiento = new DateTime(1981, 3, 23),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Jozu",
                    Biografia = "Jozu es un miembro de la segunda división de los Piratas de Barbablanca. Es un " +
                    "hombre de gran fuerza, conocido por su habilidad para usar el Haki y por su impresionante " +
                    "poder en combate.",
                    FechaNacimiento = new DateTime(1984, 7, 4),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Doflamingo Donquixote",
                    Biografia = "Doflamingo es el capitán de los Piratas Donquixote y un ex miembro de los Siete " +
                    "Guerreros del Mar. Tiene el poder de la Ito Ito no Mi, que le permite controlar hilos. Es un " +
                    "hombre manipulador y cruel, con un deseo insaciable de poder.",
                    FechaNacimiento = new DateTime(1985, 10, 24),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Oden Kozuki",
                    Biografia = "Oden es un antiguo samurái de Wano que se sacrificó para garantizar un futuro " +
                    "mejor para su país. Su legado y su espada son una fuente de inspiración para los habitantes " +
                    "de Wano y los Piratas de Sombrero de Paja.",
                    FechaNacimiento = new DateTime(1963, 9, 9),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Pica",
                    Biografia = "Pica es uno de los subordinados de Donquixote Doflamingo y uno de los principales " +
                    "antagonistas en la saga de Dressrosa. Tiene la habilidad de manipular y controlar grandes " +
                    "estructuras de piedra.",
                    FechaNacimiento = new DateTime(1988, 8, 13),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Kin'emon",
                    Biografia = "Kin'emon es un samurái proveniente de Wano. Es un miembro leal de la tripulación " +
                    "de los Piratas de Sombrero de Paja y tiene una gran habilidad con la espada. Su sueño es " +
                    "liberar Wano del dominio de Kaido.",
                    FechaNacimiento = new DateTime(1987, 1, 1),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Raizo",
                    Biografia = "Raizo es un ninja originario de Wano y un miembro de los aliados de los Piratas " +
                    "de Sombrero de Paja. Su habilidad es el ninjutsu, que le permite realizar técnicas especiales " +
                    "para ayudar a la causa.",
                    FechaNacimiento = new DateTime(1982, 3, 3),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Shinobu",
                    Biografia = "Shinobu es una ninja de Wano y una aliada clave de los Piratas de Sombrero de " +
                    "Paja. Su habilidad es el uso de jutsu y su lealtad hacia la causa de Oden y la lucha contra " +
                    "Kaido.",
                    FechaNacimiento = new DateTime(1980, 10, 21),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Monkey D. Garp",
                    Biografia = "Garp es un almirante retirado, conocido como el 'Héroe de la Marina'. Es el abuelo" +
                    " de Luffy y Ace, y se le considera uno de los hombres más poderosos de su generación. Aunque " +
                    "es muy estricto, también tiene un sentido del deber y una naturaleza algo indulgente con sus " +
                    "seres queridos.",
                    FechaNacimiento = new DateTime(1940, 5, 3),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Aokiji (Kuzan)",
                    Biografia = "Aokiji, cuyo verdadero nombre es Kuzan, es un ex almirante de la Marina que " +
                    "abandonó su puesto tras un enfrentamiento con Akainu por la posición de almirante. Tiene " +
                    "la habilidad de la Hie Hie no Mi, que le otorga el poder de controlar el hielo. A pesar " +
                    "de su naturaleza tranquila, Aokiji sigue siendo una figura clave en la lucha entre la " +
                    "Marina y los piratas.",
                    FechaNacimiento = new DateTime(1965, 12, 21),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Koby",
                    Biografia = "Koby es un antiguo marinero que comenzó su viaje con Luffy desde la pequeña " +
                    "aldea de Romance Dawn. Con el tiempo, se unió a la Marina, y gracias a su duro entrenamiento," +
                    " se convirtió en un oficial de alto rango. Su sueño es lograr la paz y justicia en el mundo.",
                    FechaNacimiento = new DateTime(1991, 3, 18),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Helmeppo",
                    Biografia = "Helmeppo es un oficial de la Marina y un gran amigo de Koby. Comenzó como un " +
                    "joven rico y mimado, pero a lo largo de la serie creció en valor y responsabilidad, " +
                    "convirtiéndose en un oficial confiable. A lo largo de su camino, demostró ser más valiente y " +
                    "determinado a cumplir con su deber.",
                    FechaNacimiento = new DateTime(1992, 6, 15),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Dr. Vegapunk",
                    Biografia = "Vegapunk es un científico genio responsable de los avances más innovadores de " +
                    "la tecnología en el mundo de One Piece. Es el creador de los Pacifistas y los Serafines, las " +
                    "armas más poderosas de la Marina, y tiene un vasto conocimiento sobre las frutas del diablo y " +
                    "los avances tecnológicos. Su laboratorio está en la isla de Egghead.",
                    FechaNacimiento = new DateTime(1978, 4, 5),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Sentomaru",
                    Biografia = "Sentomaru es el jefe de seguridad de la isla de Egghead y un miembro cercano de " +
                    "la organización de la Marina. Fue entrenado por el Dr. Vegapunk y tiene una gran habilidad " +
                    "con las armas y la lucha. Su lealtad hacia el viejo científico es inquebrantable.",
                    FechaNacimiento = new DateTime(1990, 9, 1),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "S-Snake",
                    Biografia = "S-Snake es una de los Serafines y clon de la antigua Señora de la Guerra " +
                    "del Mar Boa Hancock. Posee la misma fruta del diablo y siente debilidad cuando ve a Luffy, " +
                    "al igual que su contraparte original.",
                    FechaNacimiento = new DateTime(1995, 11, 4),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Shaka",
                    Biografia = "Shaka es uno de los seis satélites y el más filosófico. Junto con los demás " +
                    "Vegapunks, ayuda a crear nuevos avances en la ciencia. Tiene una visión única sobre la humanidad " +
                    "y su relación con la tecnología, y desempeña un papel importante en los eventos de la isla de Egghead.",
                    FechaNacimiento = new DateTime(1981, 8, 12),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Marshall D. Teach (Barbanegra)",
                    Biografia = "Barbanegra es uno de los personajes más complejos de One Piece. Ex miembro de los Piratas " +
                    "de Barbablanca, ahora es el capitán de los Piratas de Barbanegra, un grupo notorio por su ambición y " +
                    "maldad. Actualmente posee dos frutas del diablo: la Yami Yami no Mi y la Gura Gura no Mi. Su sueño es " +
                    "convertirse en el hombre más poderoso del mundo.",
                    FechaNacimiento = new DateTime(1978, 6, 15),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Shiryu",
                    Biografia = "Shiryu es el capitán de los piratas de Barbanegra y ex carcelero de Impel Down. Tiene la " +
                    "habilidad de la Sui Sui no Mi, que le permite volverse intangible como el agua. Es un espadachín " +
                    "habilidoso y uno de los miembros más temibles de la tripulación de Barbanegra.",
                    FechaNacimiento = new DateTime(1985, 7, 10),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Van Augur",
                    Biografia = "Van Augur es el francotirador de los Piratas de Barbanegra. Es un hombre astuto y " +
                    "calculador con una gran habilidad para disparar desde largas distancias, convirtiéndolo en un " +
                    "gran activo para su capitán. Además, posee la habilidad de la Wapu Wapu no Mi, que le permite " +
                    "manipular la velocidad y dirección de los objetos, además de teletransportarse.",
                    FechaNacimiento = new DateTime(1990, 12, 12),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Jesus Burgess",
                    Biografia = "Burgess es el primer oficial y un miembro prominente de los Piratas de Barbanegra. " +
                    "Es un luchador extremadamente fuerte que posee una gran ambición. Junto con el resto de la " +
                    "tripulación, busca la dominación mundial.",
                    FechaNacimiento = new DateTime(1987, 5, 19),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Doc Q",
                    Biografia = "Doc Q es uno de los miembros más singulares de los Piratas de Barbanegra. Sufre " +
                    "de problemas de salud, pero su habilidad con la medicina y su conocimiento de las personas " +
                    "lo hacen un miembro valioso de la tripulación. Su presencia y personalidad bromean con la " +
                    "muerte de una forma intrigante.",
                    FechaNacimiento = new DateTime(1989, 3, 5),
                    Foto = null
                },
                new Actor
                {
                    Nombre = "Lafitte",
                    Biografia = "Lafitte es el navegante de los Piratas de Barbanegra. Es conocido por su " +
                    "comportamiento extraño y su habilidad para volar. Es un hombre astuto que sabe cómo " +
                    "manipular a los demás para conseguir sus objetivos.",
                    FechaNacimiento = new DateTime(1993, 2, 22),
                    Foto = null

                },
            };

            context.Actor.AddRange(actores);

            // ---------------------------------------------------------------------------------------------------------------


            context.SaveChanges();

        }
    }
}
