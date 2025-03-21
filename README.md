# Prueba Técnica AZ Smart Technology LTDA


En esta prueba técnica se desarrolla una aplicación web para la gestión de una "biblioteca", desarrollada con ASP.NET MVC. La aplicación nos permite ver la lista de libros registrados, autores registrados, agregar nuevos libros y registrar nuevos autores entre muchas otras funciones. Para la interacción con la base de datos, utiliza SQL Server junto con Entity Framework. Además, se ha integrado Bootstrap para ofrecer un diseño limpio y responsive.


---

## Tabla de Contenidos
- [Descripción](#descripción)
- [Características](#características)
- [Arquitectura y Patrones de Diseño](#arquitectura-y-patrones-de-diseño)
- [Diagrama Entidad Relacion](#diagrama-entidad-relacion)
- [Tecnologias utilizadas](#tecnologías-utilizadas)
- [Requisitos](#requisitos)
- [Instalación y Configuración](#instalación-y-configuración)
- [Capturas de Pantalla](#capturas-de-pantalla)

---

## Descripción

La aplicación **Prueba Técnica AZ Smart Technology LTDA** es una versión básica de un sistema de biblioteca. Permite a los usuarios:- Visualizar la lista completa de libros registrados.
- Agregar nuevos libros mediante un formulario que solicita el título y elige un autor de una lista desplegable.
- Registrar nuevos autores a través de un formulario dedicado.

El proyecto se ha desarrollado usando ASP.NET MVC con C# y hace uso de SQL Server para almacenar los datos. La interacción con la base de datos se realiza mediante Entity Framework con LINQ. Se han implementado validaciones  en los formularios y se ha empleado Bootstrap para optimizar la experiencia de usuario en dispositivos de distintos tamaños.

---

## Características

- **Página Principal**:
  - Ver todos los libros que están registrados.
  - Ver todos los libros que están registrados.
  - Incluye botones para operaciones CRUD (ver, editar, eliminar) sobre cada libro.
  - Muestra botones para agregar un nuevo libro o un nuevo autor.
- **Crear de Libros**: Permite agregar libros proporcionando el título y seleccionando un autor existente. - **Crear de Autores**: Permite registrar nuevos autores mediante un formulario simple.
- **Lista de Autores**: Visualiza la lista de autores registrados.
- **Validaciones**: Se han implementado validaciones para asegurar la correcta entrada de datos.
- **Diseño Responsive**: Integración de Bootstrap para garantizar una interfaz moderna y adaptable.

---

## Arquitectura y Patrones de Diseño

El proyecto ha sido creado siguiendo una arquitectura en capas y se ha implementado varios patrones de diseño para promover la mantenibilidad y escalabilidad del código:

- **Arquitectura N-Capas**:  
  El proyecto está dividido en capas bien definidas, separando la lógica de presentación, la lógica de negocio y el acceso a datos.

- **Patrón Repository**:  
  Se utiliza para abstraer el acceso a la base de datos, facilitando  el mantenimiento del código.

- **Patrón Service**:  
  Encapsula la lógica de negocio y actúa como intermediario entre los controladores y la capa de acceso a datos.

- **Patrón Unit of Work**:  
  Se implementa para controlar los procesos de la base de datos y asegurarse de que las acciones de diferentes repositorios funcionen bien  sin causar errores.

---

## Diagrama Entidad Relacion
![](https://i.ibb.co/LzhdTzbh/Captura-de-pantalla-2025-03-20-212349.png)



---

## Tecnologías utilizadas
- **Lenguajes**: C#, HTML, CSS, JavaScript
- **Framework**: ASP.NET MVC
- **Base de Datos**: SQL Server
- **ORM**: Entity Framework
- **Bibliotecas adicionales**:
  - [JQuery](https://jquery.com/): Para el manejo de solicitudes y de JavaScript en el Front.
  - [Bootstrap](https://getbootstrap.com/): Para el diseño responsive.
  - [Toastr](https://github.com/CodeSeven/toastr): Notificaciones.
  - [JQuery-Confirm](https://craftpip.github.io/jquery-confirm/): Alertas elegantes.
  - [Font Awesome](https://fontawesome.com/): Iconos.
  - [DataTables](https://datatables.net/): Tablas dinámicas con Bootstrap 5.

---


## Requisitos
- **.NET Runtime:**  
  .NET 8 Runtime (asegúrate de tener instalado el SDK y Runtime de .NET 8).

- **SQL Server:**  
  Microsoft SQL Server 2012 o superior (puede usarse SQL Server Express para desarrollo).

- **Herramientas de Desarrollo:**  
  - Visual Studio 2022 o Rider (cualquier IDE que soporte .NET 8).  
  - Alternativamente, Visual Studio Code junto con la CLI de .NET 8.

## Instalación y Configuración

1. **Clonar el Repositorio**:  
   Clona este repositorio en tu máquina local:
   ```bash
   git clone https://github.com/PeterOsorioS/Prueba-Tecnica-AZ-SMART-TECHNOLOGY.git

2. **Ejecutar el Script de Base de Datos**:
En el repositorio se incluye el archivo `QueryDb.sql`. Este script crea las tablas necesarias y define las relaciones. Para ejecutarlo:
  - Abre SQL Server Management Studio (SSMS) o tu herramienta de gestión SQL preferida.
  - Conéctate a la instancia de SQL Server donde deseas crear la base de datos.
  - Abre el archivo `QueryDb.sql` desde el repositorio.
  - Ejecuta el script para crear las tablas y relaciones necesarias.

3.  **Ajustar la Cadena de Conexión**:
En el archivo `appsettings.json`, ajusta la cadena de conexión para que apunte a tu base de datos SQL Server.  
Ejemplo de configuración en `appsettings.json`:

    ```json
    {
    "ConnectionStrings": {
        "DefaultConnection": "Server=TU_SERVIDOR;Database=NombreDeTuBaseDeDatos;User=TU_USUARIO;Password=TU_CONTRASEÑA; Encrypt=false;MultipleActiveResultSets=true"
    },
    "Logging": {
        "LogLevel": {
        "Default": "Information",
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information"
        }
    },
    "AllowedHosts": "*"
    }
    ```
- Remplaza:
   **TU_SERVIDOR** con el nombre o dirección IP de tu servidor SQL.
   **TU_USUARIO** y **TU_CONTRASEÑA** con tus credenciales de SQL Server.

4. **Restaura los Paquetes NuGet**
   - Abre una terminal en la carpeta raíz de tu proyecto.
   - Ejecuta el siguiente comando:

   ```bash
   dotnet restore 

5. **Ejecuta la Aplicacion**

   - Presiona `Ctrl + F5` o selecciona `Iniciar sin depurar` para iniciar la aplicación.
   - La aplicación se abrirá automáticamente en tu navegador predeterminado, mostrando la página principal con la lista de libros y los botones para realizar operaciones CRUD.
---

## Capturas de Pantalla

<div style="display: flex; flex-direction: column;  align-items: center;">
  <p><strong>Página Principal (Lista de Libros y Botones CRUD)</strong></p>
  <img src="https://i.ibb.co/N6gxr8Yr/1.png" alt="Imagen 1" style="width: 700px; margin: 10px;">
  <img src="https://i.ibb.co/YTXb7NQK/2.png" alt="Imagen 2" style="width: 700px; margin: 10px;">
  <p><strong>Página creacion de libro</strong></p>
  <img src="https://i.ibb.co/jZzD2Zmx/3.png" alt="Imagen 3" style="width: 700px; margin: 10px;">
  <p><strong>Modal detalle de libro</strong></p>
  <img src="https://i.ibb.co/rfTsgpfN/4.png" alt="Imagen 4" style="width: 700px; margin: 10px;">
  <p><strong>Página actualizacion de libro</strong></p>
  <img src="https://i.ibb.co/rgtZ6xg/5.png" alt="Imagen 5" style="width: 700px; margin: 10px; ">
  <p><strong>Modal eliminacion de libro</strong></p>
  <img src="https://i.ibb.co/gLJDBS8D/6.png" alt="Imagen 6" style="width: 700px; margin: 10px;">
  <img src="https://i.ibb.co/d8ctwfP/7.png" alt="Imagen 7" style="width: 700px; margin: 10px; ">
</div>

---
