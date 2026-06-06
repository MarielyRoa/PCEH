# ⚡ PCEH - Predictor de Consumo Eléctrico del Hogar

PCEH es una aplicación web desarrollada en ASP.NET Core MVC que permite predecir el consumo eléctrico futuro de un hogar a partir del historial de consumo de los últimos 12 meses.

El sistema implementa diferentes métodos de análisis y predicción para ayudar a los usuarios a identificar tendencias y estimar consumos futuros.

---

## 🚀 Características

### Modos de predicción disponibles

- 📈 Promedio Móvil Simple (SMA)
- 📊 Regresión Lineal
- 📉 Variación Porcentual
- 🔍 Detección de Tendencia

### Funcionalidades

- Registro de 12 meses de consumo histórico.
- Cálculo automático de predicciones.
- Análisis del comportamiento del consumo.
- Detección de incrementos y disminuciones.
- Interfaz web intuitiva y responsive.
- Navegación entre diferentes métodos de predicción.

---

## 🏗️ Arquitectura

El proyecto fue desarrollado utilizando el patrón **MVC (Model-View-Controller)** y una arquitectura por capas.

### Estructura de la solución

```text
PCEH.Application
│
├── DTOs
├── Enums
├── Repositories
├── Services
└── ViewModels

PCEH.WebApp
│
├── Controllers
├── Views
├── wwwroot
└── Program.cs
```

### Capas

#### PCEH.Application

Contiene toda la lógica de negocio de la aplicación:

- DTOs
- Servicios de predicción
- Repositorios
- Enumeraciones
- ViewModels

#### PCEH.WebApp

Contiene la capa de presentación:

- Controladores MVC
- Vistas Razor
- Recursos estáticos
- Configuración de la aplicación

---

## 📊 Métodos de Predicción

### Promedio Móvil Simple (SMA)

Calcula el promedio de los consumos más recientes para estimar el siguiente período.

### Regresión Lineal

Utiliza una regresión lineal para proyectar el comportamiento futuro del consumo.

### Variación Porcentual

Calcula el porcentaje de cambio entre consumos consecutivos para identificar incrementos o disminuciones.

### Detección de Tendencia

Analiza el comportamiento general del consumo para determinar si existe una tendencia:

- Creciente
- Decreciente
- Estable

---

## 🛠️ Tecnologías Utilizadas

- C#
- ASP.NET Core MVC
- .NET
- Razor Views
- HTML5
- CSS3
- Bootstrap
- JavaScript

---

## 📸 Capturas de Pantalla

### Pantalla Principal
<img width="1920" height="853" alt="Pantalla Principal" src="https://github.com/user-attachments/assets/fe2f07bd-7739-47db-9d76-026d50af861b" />

### Selección de Modo de Predicción
<img width="1920" height="853" alt="Modo de Prediccion" src="https://github.com/user-attachments/assets/799c40fa-57eb-4e32-9979-aedbebd2674b" />

---

## 👩‍💻 Autor

**Mariely Roa**
