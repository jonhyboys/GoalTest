# Prueba de GoalSystem

La solución está compuesta de 3 proyectos:
- API
- FE
- Tests

# API
Este proyecto contiene el código BE de la aplicación. Esta creado con .Net Core 3.1. Intenté seguir un poco los principios SOLID y lo organicé en las siguientes carpetas:
- Interfaces
- Entities
- Service: funcionaría como repositorio, conectándose a la capa de datos.
- Controller: métodos a los que se puede acceder desde las aplicaciones externas.

Omití explicar las otras carpetas porque su nombre explica perfectamente su fin.
Utilicé un objeto propio para enviar las respuestas, con el fin de que las aplicaciones clientes, puedan presentar los mensajes de error sin necesidad de redirigir a otra página y para un mejor control de los mismos.

Algunos métodos no se lograron completar. Los de notificaciones.

# FE
Este proyecto es una aplicación Front-End que utiliza los métodos de la API, para presentar información al usuario. Tiene unos botones y controles bastantes intuitivos.

# Test
Este proyecto contiene unas pocas pruebas unitarias sobre el proyecto. Principalmente se verificó el tipo de datos devueltos y si las operaciones de agregado funcionaban.

# Probar
Hay que ejecutar el proyecto API(quitar la opción de abrir navegador si se desea) y FE. En la página de FE que se abre por defecto, se muestra la lista de productos y los controles para añadir uno nuevo. También se dejó sin corregir un problema de enrutamiento del método para eliminar producto, por lo tanto al querer eliminar uno, aparecerá un mensaje de error en la pantalla.

# Otras notas
No se agregó seguridad ni un método de autenticación. Únicamente se configuró CORS para poder alcanzar los métodos desde el código de FE.
