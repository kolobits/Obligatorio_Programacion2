# Obligatorio Programación 2 - Sistema de Marketplace

Sistema de marketplace desarrollado en .NET que permite gestionar ventas directas y subastas con interfaces web y consola.

## 🏗️ Arquitectura del Sistema

El proyecto implementa una arquitectura de 3 capas:

- **Dominio**: Lógica de negocio y entidades del sistema
- **WebApp**: Interfaz web ASP.NET Core MVC
- **UI**: Aplicación de consola para administración

## ✨ Funcionalidades Principales

### 🛒 Sistema de Ventas
- Compras directas con precios fijos
- Ofertas relámpago con 20% de descuento
- Validación de saldo disponible

### 🏆 Sistema de Subastas
- Ofertas competitivas con validación de montos
- Cierre administrativo con selección automática del ganador
- Gestión de estados (ABIERTA, CERRADA, CANCELADA)

### 👥 Gestión de Usuarios
- Autenticación con roles (Cliente/Administrador)
- Manejo de sesiones HTTP
- Sistema de billetera virtual

## 🚀 Tecnologías Utilizadas

- **.NET 6+** - Framework principal
- **ASP.NET Core MVC** - Interfaz web
- **C#** - Lenguaje de programación
- **Entity Framework** - Manejo de datos (en memoria)
- **Bootstrap** - Estilos CSS

## 📋 Requisitos del Sistema

- .NET 6.0 SDK o superior
- Visual Studio 2022 o VS Code
- Navegador web moderno

## ⚙️ Instalación y Configuración

1. **Clonar el repositorio**
```bash
git clone https://github.com/kolobits/Obligatorio_Programacion2.git
cd Obligatorio_Programacion2/Obligatorio1
```

2. **Restaurar dependencias**
```bash
dotnet restore
```

3. **Ejecutar la aplicación web**
```bash
cd WebApp
dotnet run
```

4. **Ejecutar la aplicación de consola**
```bash
cd UI
dotnet run
```

## 🔐 Usuarios de Prueba

### Administradores
- **Email**: `adressalvanos@gmail.com` | **Contraseña**: `exonerar2024`
- **Email**: `pedroperez@gmail.com` | **Contraseña**: `Admin123`

### Clientes
- **Email**: `juanrodriguez@gmail.com` | **Contraseña**: `contrasenia1`
- **Email**: `anagomez@gmail.com` | **Contraseña**: `contrasenia2`

## 🎯 Funcionalidades por Rol

### Cliente
- ✅ Registrarse en el sistema
- ✅ Realizar compras directas
- ✅ Participar en subastas
- ✅ Recargar billetera virtual
- ✅ Ver historial de transacciones

### Administrador
- ✅ Cerrar subastas 
- ✅ Gestionar publicaciones
- ✅ Ver reportes del sistema
- ✅ Administrar usuarios

## 📊 Datos de Prueba

El sistema incluye datos precargados: 
- 10 clientes con saldos variados
- 2 administradores
- 50 artículos en diferentes categorías
- 10 ventas activas
- 10 subastas en diferentes estados

## 🏃‍♂️ Guía de Uso Rápido

### Interfaz Web
1. Navegar a `https://localhost:5001`
2. Iniciar sesión con credenciales de prueba
3. Explorar publicaciones disponibles
4. Realizar compras o participar en subastas

### Interfaz de Consola
1. Ejecutar `dotnet run` en el proyecto UI
2. Seleccionar opciones del menú:
   - Listar clientes
   - Filtrar artículos por categoría
   - Agregar nuevos artículos
   - Consultar publicaciones por fecha

## 🔧 Estructura del Proyecto

```
Obligatorio1/
├── Dominio/           # Lógica de negocio
│   ├── Sistema.cs     # Singleton principal
│   ├── Usuario.cs     # Entidades de usuario
│   ├── Publicacion.cs # Ventas y subastas
│   └── Articulo.cs    # Productos del sistema
├── WebApp/            # Interfaz web MVC
│   ├── Controllers/   # Controladores
│   ├── Views/         # Vistas Razor
│   └── Program.cs     # Configuración
└── UI/                # Aplicación consola
    └── Program.cs     # Menú principal
```

## 🐛 Validaciones Implementadas

- **Artículos**: Nombre, categoría y precio obligatorios
- **Publicaciones**: Nombres no vacíos y estados válidos
- **Transacciones**: Saldo suficiente y montos positivos
- **Subastas**: Ofertas superiores a la actual

## 📝 Notas de Desarrollo

- El sistema utiliza el patrón Singleton para `Sistema.cs`
- Los datos se almacenan en memoria (no persistentes)
- Implementa validaciones robustas en todas las entidades
- Manejo de excepciones centralizado
- Separación clara de responsabilidades por capas


---

**Desarrollado como proyecto académico - Universidad ORT Uruguay**
