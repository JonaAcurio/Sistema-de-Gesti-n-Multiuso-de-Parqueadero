# Acta de Avance Semanal: Proyecto SGP PUCESA

**Semana:** 1 (Validada el 25/02/2026)
**Estado del Proyecto:** Requerimientos e Integración Técnica con Hardware
**Responsables:** Equipo de Ingeniería SGP

## 1. Resumen Ejecutivo
Durante la primera semana del proyecto, la prioridad fue establecer una comunicación estable entre el software en desarrollo y el hardware de las barreras físicas. Se logró resolver fallos de cableado crítico en el panel inBio 260, habilitando lecturas de sensores RFID (Tags) y accionamientos automáticos. Simultáneamente, se iniciaron las reuniones de levantamiento de requerimientos con los *Stakeholders* de la PUCESA para validar las bases del sistema local y la futura plataforma web.

## 2. Desarrollo de Software y Prototipado
- **Arquitectura de Software:** El sistema se dividió en dos soluciones integradas:
  - **Sistema Local (Garita):** Aplicación de escritorio diseñada para alta disponibilidad sin dependencia de internet.
  - **Plataforma Web:** Orientada a la comunidad para pagos y gestión de perfiles (en fase de auditoría local).
- **Despliegue Beta 2.0 (Local):** Se liberó una versión temprana de la aplicación de garita que incluye la lógica inicial de sensores TAG y el registro de incidencias físicas.
- **Stack Tecnológico Base:** Se configuró el entorno con .NET 8 SDK, bases de conexión con SQLClient y seguridad de contraseñas mediante encriptación BCrypt.

## 3. Integración y Optimización de Hardware
- **Resolución de Fallos Críticos:** Se corrigió un error de cableado interno en 40 minutos que impedía el levantamiento mecánico de las plumas, a pesar de que el software enviaba la orden correcta.
- **Automatización y Sensores:**
  - **Rehabilitación Manual:** Se reconectó el botón de emergencia físico en cabina por seguridad.
  - **Lectura de TAGs:** Se conectaron las antenas RFID, posibilitando que el sistema controle la apertura de la pluma al detectar un vehículo.
  - **Sensores de Pluma:** Se habilitó la lectura que permite al sistema saber si la pluma se subió o se bajó, y por qué motivo.

## 4. Gestión de Stakeholders y Requerimientos
- **Alineación con TI:** Se abrieron canales de comunicación con el departamento de TI de la universidad para coordinar permisos de red y acceso a equipos.
- **Levantamiento de Información:** Reuniones directas con los interesados para entender el flujo vehicular real y redactar la matriz de requerimientos preliminares.
- **Arquitectura de Datos (Inicial):** Se finalizó el diagrama lógico de base de datos que soportará tanto al sistema de escritorio como a la futura plataforma web.

## 5. Riesgos, Errores y Mitigación
- **Riesgo Ambiental:** Fuertes lluvias obligaron a suspender las pruebas de hardware en exteriores para proteger las placas de los equipos (Panel InBio).
- **Mitigación:** Para no detener el avance, el equipo reasignó recursos y tiempo a corregir fallos lógicos en el prototipo de la aplicación .NET dentro de la oficina.

## 6. Siguientes Pasos (Pendientes)
- **Implementación de Base de Datos:** Creación física de tablas según la infraestructura planteada (SQL Server).
- **Sincronización Web-Garita:** Iniciar pruebas de transferencia de datos de pagos desde la plataforma web a la aplicación de garita.
- **Control de Versiones (DevOps):** Creación y configuración de repositorios colaborativos en GitHub.
- **Mejora de Interfaces:** Refinar aspectos visuales del aplicativo para el usuario final.

---
**Nota del Consultor:**
*Para la integración del panel inBio 260 con la red, se requirió registrar las librerías propietarias `plcommpro.dll` y `pltcpcomm.dll` en el entorno Windows. A partir de ahora, la lógica de cierre se centraliza en este panel; es crítico respetar el diagrama de instalación de hardware actual en la garita.*

---

## Fe de erratas documental - 2026-07-17

**Código documental:** CP-ACT-FE-001  
**Estado:** Nota aclaratoria agregada durante la fase de estabilización conceptual

Esta fe de erratas no reemplaza el contenido histórico del acta. Su propósito es aclarar cómo debe interpretarse en la documentación vigente:

- El acta se conserva como evidencia histórica de avance y no como fuente única de decisiones aprobadas.
- La denominación oficial vigente del sistema pasó a ser **Cato Parking**, manteniendo `SGP` como referencia histórica.
- El controlador documental objetivo aprobado es **ZKTeco InBIO 260**.
- Las referencias específicas a librerías, eventos, lectores, relés y topología de hardware deben leerse como información histórica o técnica preliminar, salvo donde exista validación técnica formal.
- La plataforma web, SQL Server, SSO y demás módulos institucionales no deben considerarse implementados solo por aparecer mencionados en esta acta.
