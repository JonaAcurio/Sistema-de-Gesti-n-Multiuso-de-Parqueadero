# 📘 Guía de Documentación del Proyecto

Esta guía explica la estructura de carpetas y el contenido de la documentación del sistema de gestión de parqueadero.

## 📂 Estructura de Carpetas

La documentación se organiza en las siguientes categorías principales dentro de la carpeta `Documentos/`:

### 📁 01_Gestion_Proyecto
Contiene toda la información administrativa y técnica de alto nivel.
-   **Actas_de_Reuniones/**: Minutas de las reuniones semanales (Semanas 1 a 4) y guías de redacción.
-   **Informes_Tecnicos/**: Documentos técnicos específicos como el diseño de la base de datos, configuración del servidor, UX/UI y solicitudes de hardware.
-   `Task_List.md`: Seguimiento detallado de tareas y pendientes.

### 📁 02_Requisitos_y_Analisis
Documentación sobre qué debe hacer el sistema y cómo se diseñó.
-   **Arquitectura/**: Diagramas de componentes y lógica del sistema.
-   **Plantillas/**: Formatos estándar para nuevos documentos.
-   **UX_UI/**: Mockups y lineamientos de experiencia de usuario.

### 📁 03_Base_de_Datos
Todo lo relacionado con el almacenamiento de datos.
-   **Esquema/**: Diagramas de entidad-relación y scripts SQL.

### 📁 04_Desarrollo
Información técnica para desarrolladores y mantenimiento.
-   **Estandares/**: Reglas de codificación y naming.
-   **Guia_Git/**: Procedimientos para el control de versiones.
-   `Guia_Errores_y_Soluciones.md`: **[IMPORTANTE]** Historial de bugs corregidos y cómo actuar ante fallos comunes.

---

## 🛠️ Documentos Clave

1.  **[Guía de Errores y Soluciones](file:///e:/a/Documentos/04_Desarrollo/Guia_Errores_y_Soluciones.md)**: Referencia rápida para resolución de problemas conocidos.
2.  **[Task List](file:///e:/a/Documentos/01_Gestion_Proyecto/Task_List.md)**: Estado actual del proyecto.
3.  **[README Principal](file:///e:/a/README.md)**: Resumen técnico y guía de instalación.

> [!NOTE]
> Toda la documentación nueva debe seguir los estándares definidos en la carpeta `02_Requisitos_y_Analisis/Plantillas`.
## Nota de estabilización documental - 2026-07-17

Durante la fase de estabilización conceptual, la fuente de verdad documental del proyecto pasa a depender prioritariamente de:

- `Documentos/00_Gobierno_Documental/`
- `Documentos/01_Gestion_Proyecto/Alcance/`
- `Documentos/01_Gestion_Proyecto/Control/`
- `Documentos/01_Gestion_Proyecto/Stakeholders/`

Toda nueva redacción debe distinguir explícitamente entre:

- decisión aprobada;
- decisión propuesta;
- supuesto técnico;
- requisito pendiente de validación;
- funcionalidad implementada;
- funcionalidad en desarrollo;
- funcionalidad prevista para el sistema completo.
