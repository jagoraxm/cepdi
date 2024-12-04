# CEPDI

Este repositorio contiene dos proyectos principales desarrollados en .NET Core:

1. WebAPICepdi: Una API RESTful para manejar la lógica de negocio y la comunicación con la base de datos sobre dos modelos (Usuarios y Medicamentos).
2. WebAppCepdi: Una aplicación web que consume la API y ofrece una interfaz gráfica al usuario para realizar el CRUD de los dos modelos.

---

## Tabla de Contenidos
1. [Características](#características)
2. [Tecnologías Utilizadas](#tecnologías-utilizadas)
3. [Estructura del Proyecto](#estructura-del-proyecto)
4. [Requisitos Previos](#requisitos-previos)
5. [Instalación](#instalación)
6. [Uso](#uso)
7. [Contribuciones](#contribuciones)
8. [Licencia](#licencia)

---

## Características

### WebAPI
- Implementación de una API RESTful.
- Soporte para operaciones CRUD.
- Manejo de errores centralizado.
- Documentación interactiva con Swagger.

### WebApp
- Interfaz desarrollada en .NET Core MVC.
- Integración con la WebAPI para consumo de datos.
- Autenticación interna de solo validación.

---

## Tecnologías Utilizadas
- Lenguaje: C#.
- Framework: .NET Core 7.0 (o superior).
- Base de Datos: SQL Server con conexión remota.
- Cliente JQuery para consumo de la API.
- Frontend: Razor Pages.
- Otros: Swagger para documentación, Entity Framework Core para acceso a datos.

---

## Estructura del Proyecto

```plaintext
/
├── WebAPI/              # Proyecto de API RESTful
│   ├── Controllers/     # Controladores de la API
│   ├── Models/          # Modelos de datos
│   ├── Data/            # Contexto de base de datos
│   └── Program.cs       # Configuración inicial
│
├── WebApp/              # Proyecto de aplicación web
│   ├── Controllers/     # Controladores de la web
│   ├── Views/           # Vistas Razor
│   ├── wwwroot/         # Archivos estáticos (CSS, JS, imágenes)
│   └── Program.cs       # Configuración inicial
│
└── README.md            # Documentación del repositorio
```

---

## Requisitos Previos
- SDK de .NET Core 6.0
- SQL Server
- Visual Studio 2022 o superior.

---

## Instalación
1. Clonar el Repositorio
```
git clone https://github.com/jagoraxm/cepdi.git
cd cepdi
```

2. Configurar la Base de Datos
Crear una base de datos en SQL Server.
Actualizar las cadenas de conexión en appsettings.json para ambos proyectos:

"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}

3. Aplicar Migraciones
Desde la carpeta WebAPI, ejecutar:
```
dotnet ef database update
```

4. Iniciar los Proyectos
WebAPI:
```
cd WebAPI
dotnet run
```

WebApp:
```
cd WebApp
dotnet run
```

Ambos proyectos estarán disponibles en sus respectivas direcciones locales.

Uso
WebAPI
Accede a la documentación de la API generada automáticamente en:

```
http://localhost:5000/swagger
```

WebApp
Abre el navegador y visita:
```
http://localhost:5001
```

Contribuciones
¡Las contribuciones son bienvenidas! Por favor, sigue estos pasos:

Haz un fork del repositorio.
Crea una rama con el nombre de tu característica: git checkout -b feature/nueva-caracteristica.
Realiza un commit de tus cambios: git commit -m 'Agregada nueva característica'.
Haz push a la rama: git push origin feature/nueva-caracteristica.
Crea un Pull Request.

Licencia
Este proyecto está licenciado bajo la licencia MIT. Consulta el archivo LICENSE para más información.

Si necesitas ayuda con algún detalle adicional, ¡avísame! 😊
