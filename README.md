📝 Descripción Detallada del Proyecto "Pokédex en C# .NET WinForms"
🎯 Objetivo General:
El objetivo del proyecto es construir una Pokédex funcional utilizando Windows Forms en C# .NET, aplicando los principios de la Programación Orientada a Objetos (POO) como encapsulamiento, persistencia de datos y diseño modular.

📦 Estructura del Proyecto:

1. Clases y Encapsulamiento (POO)

Se creó una clase Pokemon que encapsula todos los atributos relevantes de un Pokémon:

-Nombre

-Nivel

-TipoPrimario

-TipoSecundario

-CaracteristicaPrincipal

-Habilidades (lista de strings)

Se utilizaron métodos como ObtenerResumen() y ObtenerDetalle() para abstraer la lógica de presentación de datos, mostrando información resumida o completa del Pokémon seleccionado.

Persistencia con JSON
Se implementó una clase Pokedex para:

Guardar y cargar datos desde un archivo .json.

Asegurar que la información de los Pokémon registrados se mantenga entre sesiones del programa.

El archivo .json contiene una lista de los primeros 150 Pokémon de la temporada original, permitiendo autocompletado o referencia cruzada.

🖥️ Interfaz de Usuario (WinForms)
Componentes:
-TextBoxes: Para ingresar nombre, nivel, tipos, características y habilidades.

-ListBox (lstPokemones): Muestra los Pokémon agregados.

-TextBox de detalles (txtDetalle): Muestra información detallada del Pokémon seleccionado.

Botones:

-Agregar Pokémon: Valida y guarda un nuevo Pokémon.

-Buscar: Filtra Pokémon por nombre.

-Eliminar: Elimina el Pokémon seleccionado de la lista.

-Limpiar búsqueda: Restaura la lista completa.

Validaciones:
-No se permite ingresar números en el nombre del Pokémon (bloqueo directo en el evento KeyPress).

-El campo de nivel solo acepta números entre 1 y 200.

-Se muestra un mensaje de éxito al registrar un Pokémon: "¡Pokémon registrado en la Pokédex!".

Funcionalidad Visual:
-Al buscar un Pokémon, solo se muestra la lista filtrada.

-Al seleccionar un Pokémon, su información se muestra detalladamente en el panel derecho.

-Se utilizan emojis como ⚡🐭 (Pikachu simbólico) y 📦 para dar estilo visual.

-Existe la posibilidad de agregar imágenes con PictureBox para una experiencia más rica.

🔄 Ejecución del Programa:
El usuario ingresa los datos de un Pokémon y presiona Agregar.

El programa valida los datos y guarda la información en un archivo .json.

El Pokémon aparece en la lista y puede ser buscado por nombre.

Al seleccionarlo, se muestra su información en detalle.

El usuario puede eliminar Pokémon o limpiar búsquedas según desee.

💡 Características Técnicas:
Lenguaje: C# .NET Framework

Interfaz: WinForms

Persistencia: Serialización JSON (usando System.Text.Json)

Encapsulamiento: Separación clara entre lógica de datos y UI

Escalabilidad: El sistema permite seguir agregando Pokémon o expandir a nuevas generaciones

Ejemplo de Pokémon:

![image](https://github.com/user-attachments/assets/ac51075a-053a-4185-a429-e06807422cfa)
