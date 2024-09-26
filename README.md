# ApiRestTasks

## Descripción

ApiRestTasks es una API RESTful desarrollada en .NET Core que gestiona un sistema de asignación de tareas. Esta API proporciona funcionalidad para la gestión de usuarios, roles y tareas, con autenticación mediante JWT y un sistema de roles jerárquico.

## Características

- **Autenticación JWT**: Permite a los usuarios autenticarse mediante un token.
- **Sistema de roles**: Administra usuarios con diferentes roles (Administrador, Supervisor, Empleado) para limitar el acceso a funcionalidades específicas.
- **Gestión de tareas**: CRUD de tareas con asignación a usuarios y actualización de estado.
- **Gestión de usuarios**: CRUD de usuarios con asignación de roles.

## Tecnologías utilizadas

- **.NET Core 8.0**: Framework utilizado para desarrollar la API.
- **Entity Framework Core**: ORM para la interacción con la base de datos.
- **JWT (Json Web Token)**: Para autenticación y autorización.
- **SQL Server**: Base de datos relacional.

## Estructura del proyecto

├── Controllers # Controladores que gestionan las peticiones HTTP ├── Models # Modelos y entidades del sistema (Usuario, Rol, Tarea) ├── DTOs # Data Transfer Objects utilizados para comunicación entre el cliente y la API ├── Services # Servicios que contienen la lógica de negocio ├── Repositories # Repositorios que interactúan con la base de datos mediante EF Core └── obj # Archivos temporales generados por .NET


## Instalación y configuración

1. **Clona el repositorio**:

   ```bash
   git clone https://github.com/dvpkelmer/ApiRestTasks.git
   cd ApiRestTasks

Configura la base de datos:

Asegúrate de tener una instancia de SQL Server configurada y actualiza las cadenas de conexión en appsettings.json.
dotnet restore
dotnet ef database update
