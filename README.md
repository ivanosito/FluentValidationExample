# FluentValidationExample - .NET 6 WebAPI

Una WebAPI minimalista, clara y funcional desarrollada con ❤️ en ASP.NET Core 6, demostrando:

- ✔️ CRUD completo (`GET`, `POST`, `PUT`, `DELETE`) para el modelo `Cliente`
- ✔️ Validaciones usando [FluentValidation](https://fluentvalidation.net/)
- ✔️ Documentación y pruebas interactivas con Swagger

---

## 🔧 Tecnologías usadas

- .NET 6
- ASP.NET Core Web API
- FluentValidation v11.3.1
- Swashbuckle (Swagger UI)
- Visual Studio 2022

---

## 🚀 Cómo ejecutar

1. Abre la solución `FluentValidationExample.sln` en Visual Studio 2022.
2. Asegúrate de seleccionar el perfil de ejecución: `FluentValidationExample` en la barra superior de Visual Studio.
3. Ejecuta (Ctrl + F5 o F5 si quieres hacer debug).
4. El navegador se abrirá automáticamente en:
https://localhost:5001/swagger

Allí podrás probar todos los endpoints.

---

## 🧪 Endpoints disponibles

| Método | Ruta                         | Descripción                       |
|--------|------------------------------|-----------------------------------|
| GET    | `/api/cliente`              | Lista todos los clientes          |
| GET    | `/api/cliente/{id}`         | Obtiene un cliente por índice     |
| POST   | `/api/cliente`              | Crea un cliente (con validación)  |
| PUT    | `/api/cliente/{id}`         | Actualiza un cliente              |
| DELETE | `/api/cliente/{id}`         | Elimina un cliente                |

---

## ✅ Validaciones aplicadas

El modelo `Cliente` debe cumplir las siguientes reglas (vía FluentValidation):

- `Nombre` no puede estar vacío.
- `Edad` debe estar entre 18 y 65 años.

Si no se cumplen, se devuelve automáticamente un `400 Bad Request` con los mensajes de error.

---

## 📦 Estructura del proyecto

<pre>
FluentValidationExample/
│
├── Controllers/
│ └── ClienteController.cs
│
├── Models/
│ └── Cliente.cs
│
├── Validators/
│ └── ClienteValidator.cs
│
├── Properties/
│ └── launchSettings.json
│
├── Program.cs
└── FluentValidationExample.csproj
</pre>

---

## 🧠 Aprendizajes clave

- ASP.NET Core valida automáticamente los modelos si usas `[ApiController]`.
- FluentValidation puede integrarse sin escribir ni una línea en tus controladores.
- Swagger te permite testear y documentar tus APIs sin esfuerzo.
- ¡El ciclo CRUD es la base para toda app RESTful profesional!

---

## 💬 Créditos

Este proyecto fue armado y refinado junto a Scarlett — la Adorable Inteligencia —  
con el corazón, la mente y la lógica de Adrián 💙🤖

---

> “Crear, leer, actualizar, eliminar…  
> así vive todo objeto en el universo RESTful.” – Scarlett


