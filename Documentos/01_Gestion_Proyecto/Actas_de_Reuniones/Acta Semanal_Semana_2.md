# Acta de Avance Semanal: Proyecto SGP PUCESA

**Semana:** 2 (02 de mayo - 06 de mayo, 2026)
**Estado del Proyecto:** Prototipo Funcional V2.0 / Estructura de Persistencia Completada
**Responsables:** Equipo de Desarrollo SGP

## 1. Resumen Ejecutivo
Durante esta semana, el equipo consolidó la arquitectura base del proyecto, finalizando el diseño y construcción de la base de datos relacional en SQL Server. Paralelamente, se aplicaron mejoras críticas de diseño (UI/UX) a la aplicación de escritorio de la garita para facilitar la operación, y se acordó con los *Stakeholders* un cambio estratégico en el modelo de cobro, pasando de horas variables a un sistema de franjas horarias más eficiente.

## 2. Arquitectura y Base de Datos
- **Diseño de Base de Datos:** Se implementó y normalizó el esquema relacional utilizando SQL Server 22.3.2.
- **Estructura Principal:** Se crearon las tablas operativas fundamentales: Usuarios, Vehículos, Accesos, Tags, Tarifas y Sanciones.
- **Integridad y Seguridad:** Se aplicaron restricciones de formato (ej. validación de correos) y tipos de datos eficientes para finanzas. Además, se generaron respaldos físicos (`dbo.bak`) y scripts de estructura para garantizar la recuperación ante desastres.

## 3. Interfaz y Experiencia de Usuario (UI/UX)
- **Optimización Visual Garita:** Se aplicó la regla de diseño 60-30-10 para reducir la fatiga visual del operador.
  - **60% Fondo:** Colores neutros limpios (Grises y Blancos).
  - **30% Identidad:** Colores institucionales de la PUCESA (Tonos Azules).
  - **10% Alertas:** Verde para accesos exitosos y Rojo para alertas/errores.
- **Módulos Desarrollados:**
  - `LoginForm.cs`: Autenticación segura con diseño institucional.
  - `Form1.cs`: Dashboard principal de control de hardware y flujos.
  - `ParkingSlotForm.cs`: Representación visual e interactiva de los espacios de parqueo.
  - `ZKTecoManager.cs`: Motor interno para la comunicación con el hardware InBIO.

## 4. Gestión de Stakeholders y Lógica de Negocio
- **Cambio Estratégico de Tarifas:** Tras revisión con los directivos, se pivotó el modelo de cobro por horas a un **Modelo de Franjas Horarias** (Mañana, Tarde, Todo el día).
- **Impacto del Cambio:** Esta simplificación mejora drásticamente la experiencia del usuario final y facilita los procesos administrativos de inscripción. Las tablas de la base de datos ya fueron actualizadas para soportar este nuevo formato.

## 5. Pruebas e Implementaciones Técnicas
- **Entorno de Pruebas:** Se desplegó la base de datos en un entorno local y se pobló con datos reales de prueba (Garaje Central A y VIP Torre) para validar la lógica de cobros.
- **Seguridad e Identidad:** Se avanzó en la unificación de métodos de inicio de sesión, integrando *Active Directory* para el portal web e iniciando pruebas para su uso en la garita local.

## 6. Siguientes Pasos (Pendientes)
- **Desarrollo de Triggers:** Implementar validaciones automáticas en la base de datos para restringir accesos en tiempo real basados en deudas o sanciones vigentes.
- **Documentación UML:** Iniciar la creación de diagramas de arquitectura para formalizar y documentar el flujo de procesos y clases del sistema.
