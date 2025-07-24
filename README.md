
# 🏪 Obligatorio Programación 2 - Sistema de Marketplace

Este proyecto fue desarrollado como parte del curso **Programación 2** en la carrera de **Analista en Tecnologías de la Información** en la Universidad ORT Uruguay. Consiste en un sistema de marketplace que permite a los usuarios realizar **compras directas** y participar en **subastas**, utilizando interfaces tanto web como de consola.

---

## 🧱 Arquitectura del Sistema

El sistema está dividido en 3 capas principales:

- **Dominio**: lógica de negocio, entidades y validaciones.
- **WebApp**: interfaz web construida con ASP.NET Core MVC.
- **UI (Consola)**: herramienta administrativa de línea de comandos.

---

## ✨ Funcionalidades Clave

### 🛍️ Ventas Directas
- Visualización de productos disponibles.
- Compras con validación de saldo.
- Ofertas relámpago con descuento aplicado.

### 🔨 Subastas
- Usuarios ofertan en subastas activas.
- Cierre manual por administrador.
- Validación de montos y selección automática del ganador.
- Estados: `ABIERTA`, `CERRADA`, `CANCELADA`.

### 👤 Gestión de Usuarios
- Autenticación con roles (`Cliente`, `Administrador`).
- Inicio de sesión web con manejo de sesiones HTTP.
- Billetera virtual para cada usuario.

---

## 🚀 Tecnologías Usadas

- `.NET 6` – Framework base
- `ASP.NET Core MVC` – Web frontend
- `Entity Framework (InMemory)` – Acceso a datos
- `C#` – Lógica de negocio
- `Bootstrap` – Estilos y diseño responsivo

---

## 📦 Requisitos

- .NET 6.0 SDK o superior
- Visual Studio 2022 o Visual Studio Code
- Navegador moderno (Chrome, Firefox, Edge)

---

## 🎯 Funcionalidades por Rol

### Cliente
- Registro e inicio de sesión
- Compras directas
- Participación en subastas
- Recarga de billetera
- Visualización de historial

### Administrador
- Cierre de subastas
- Gestión de artículos y publicaciones
- Visualización de reportes
- Administración de usuarios

---

## 📊 Datos Precargados

- 10 clientes con diferentes saldos
- 2 administradores
- 50 artículos
- 10 ventas activas
- 10 subastas en distintos estados

---

## ✅ Validaciones Implementadas

- Artículos con nombre, categoría y precio obligatorios
- Publicaciones con nombre no vacío y estado válido
- Subastas con ofertas válidas y control de duplicados
- Saldo mínimo requerido para cada transacción
- Ofertas superiores al mínimo actual

---

## 🧠 Notas de Diseño

- Se utiliza patrón Singleton para la clase `Sistema`
- Persistencia en memoria (sin base de datos real)
- Separación clara por responsabilidades
- Manejo de errores centralizado
- Validaciones estrictas en todas las entidades

---

## 👨‍💻 Autores

- **Camilo Pardo**
- **Matías Lemos** - 241970

Desarrollado como parte del curso **Programación 2 - Universidad ORT Uruguay**
