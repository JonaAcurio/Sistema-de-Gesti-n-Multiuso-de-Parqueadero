# 🅿️ Sistema de Gestión Multiuso de Parqueadero

Sistema centralizado para la administración inteligente de espacios de estacionamiento, diseñado para optimizar el control de acceso y la gestión financiera mediante la integración de hardware y software en entornos universitarios.

---

## 📋 Descripción del Proyecto
Este sistema permite gestionar de forma integral el ciclo de vida de un estacionamiento, automatizando procesos que tradicionalmente son manuales:

* **Control de Acceso:** Validación física y lógica mediante tecnología de sensores y lectores (TAG/RFID).
* **Gestión de Cobros:** Lógica de negocio para el cálculo de tarifas fijas, por hora o fracción de tiempo.
* **Reglas de Negocio:** Aplicación automatizada de sanciones y manejo de perfiles diferenciados (Estudiantes, Docentes, Administrativos).
* **Módulo Administrativo:** Panel para la asignación dinámica de espacios y visualización de reportes de ocupación.

---

## 🛠️ Stack Tecnológico y Versiones
Para asegurar la estabilidad y compatibilidad del sistema, se recomienda el uso de las siguientes versiones:

| Componente | Tecnología | Versión Sugerida |
| :--- | :--- | :--- |
| **Lenguaje** | C# | 12.0 |
| **Framework** | .NET (Core) | 8.0 (LTS) |
| **Base de Datos** | PostgreSQL / MySQL | 15.x+ / 8.0+ |
| **Hardware Interfacing** | SerialPort (System.IO.Ports) | 8.0+ |
| **Documentación** | Markdown / PDF | - |

---

## 📂 Estructura del Repositorio
El proyecto se organiza en los siguientes módulos principales:

* **`📂 DataBase/`**: Contiene los scripts de definición de datos (DDL), triggers para la automatización de sanciones y procedimientos almacenados para la lógica de cobro.
* **`📂 parqueadero-docs/`**: Documentación técnica detallada, diagramas de entidad-relación (MER) y manuales de usuario/instalación.
* **`📂 parqueadero-hardware-bridge/`**: Código fuente en C#/.NET encargado de la comunicación entre el software de gestión y los componentes físicos (lectores de tarjetas, talanqueras y sensores).

---

## 🚀 Instalación y Configuración

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/tu-usuario/SistemaDeGestionMultiusoDeParqueadero.git](https://github.com/tu-usuario/SistemaDeGestionMultiusoDeParqueadero.git)
    ```

2.  **Configurar la Base de Datos:**
    * Acceder a la carpeta `📂 DataBase/`.
    * Ejecutar los scripts SQL en su gestor de base de datos preferido para crear las tablas, relaciones y triggers.

3.  **Configurar el Proyecto .NET:**
    * Abrir la solución `.sln` en Visual Studio o VS Code.
    * Restaurar dependencias y compilar:
        ```bash
        dotnet restore
        dotnet build
        ```

---

## 👥 Autores
* **Jonathan Acurio**
* **Carlos Parreño**

---

## ⚖️ Licencia
Este proyecto es de carácter estrictamente académico para la comunidad universitaria.