



![](Aspose.Words.e3cbbdf5-5095-4777-9964-9a2f509705d0.004.png)




![](Aspose.Words.e3cbbdf5-5095-4777-9964-9a2f509705d0.001.png)![](Aspose.Words.e3cbbdf5-5095-4777-9964-9a2f509705d0.002.png)![](Aspose.Words.e3cbbdf5-5095-4777-9964-9a2f509705d0.003.png)![](Aspose.Words.e3cbbdf5-5095-4777-9964-9a2f509705d0.005.png) 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# **Acta de Avance Semanal** 
# **Proyecto: Sistema de Gestión Multisitio de Parqueaderos** 
# **Revisión: 2.0 (Actualizada al 27/02/2026)**
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 

|<h1> </h1><br>**![](Aspose.Words.e3cbbdf5-5095-4777-9964-9a2f509705d0.006.png)** </h1>|<h1>** </h1>|<h1></h1>|<p><h1>** </h1></p><p><h1>** </h1></p>|
| :-: | :-: | -: | -: |
# **Ficha del documento**
# ** 
# ** 

|<h1>**Fecha** </h1>|<h1>**Revisión** </h1>|<h1>**Cambios realizados**</h1>|
| :-: | :-: | :-: |
|<h1>23/02/2026 </h1>|<h1>1\.0</h1>|<h1>Fase de Requerimientos e Integración Técnica con Hardware</h1>|
|<h1>27/02/2026</h1>|<h1>2\.0</h1>|<h1>Resolución de fallos de hardware, integración de sensores TAG y despliegue de Beta 2.0</h1>|
|<h1></h1>|<h1></h1>|<h1> </h1>|
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# ** 
# Documento validado por las partes en fecha: 25/02/2026
# ** 

|<h1>Por el cliente </h1>|<h1>Por la empresa suministradora </h1>|
| :-: | :-: |
|<h1>** </h1>|<p><h1>** </h1></p><p><h1>** </h1></p><p><h1>** </h1></p><p><h1>** </h1></p><p><h1>** </h1></p><p><h1>** </h1></p><p><h1>** </h1></p>|
|<h1>De </h1>|<h1>Fdo. D./Dña  </h1>|
# <a name="_r3itea1nhwn3"></a> 

## **1. Resumen Ejecutivo**
Durante la presente semana, el equipo de ingeniería concentró sus esfuerzos en una estrategia dual: la validación técnica de hardware para el control de barreras vehiculares y el levantamiento de requerimientos con los interesados directos (stakeholders) de la PUCESA.

Los pilares de este periodo incluyen la consolidación de la comunicación bidireccional entre el software y la infraestructura física del panel inBio 260. Se resolvieron errores críticos de cableado que afectaban el pulso eléctrico de las plumas, garantizando que el estado lógico coincida con el movimiento mecánico. Además, se evolucionó hacia la Versión Beta 2.0 del sistema local, integrando sensores de TAGs (RFID) y aprovechando los sensores internos de las barreras para el registro de eventos en tiempo real. Finalmente, se validó el prototipo de la interfaz web bajo el stack de .NET 8, asegurando una plataforma escalable para la gestión de pagos y permisos de la comunidad universitaria.
## **2. Actividades Realizadas y Logros**
## **2.1. Gestión de Stakeholders e Infraestructura**
- ## **Alineación Estratégica con TI:** Se establecieron canales de acceso con el departamento de TI para la gestión de equipos y permisos de red.
- ## **Definición de Necesidades PUCESA:** Reuniones con interesados para la recolección de datos estadísticos, permitiendo refinar el flujo vehicular real.
- ## **Diseño de Arquitectura de Datos:** Se finalizó el planteamiento de la infraestructura de la base de datos (diagrama de tablas) para dar soporte tanto a la aplicación local como a la plataforma web.
- ## **Documentación Técnica:** Redacción de la matriz de requerimientos preliminares, estableciendo el marco legal y técnico de trabajo.
## **2.2. Integración y Optimización de Hardware (Hito Crítico)**
- ## **Resolución de Fallos de Accionamiento:** Se detectó y corrigió en 40 minutos un error de cableado interno que impedía el levantamiento físico de la pluma a pesar de que el sistema registraba la orden de apertura.
- ## **Rehabilitación de Emergencia:** Se restableció la funcionalidad del botón físico de la garita, integrándolo nuevamente al circuito de control para protocolos de seguridad manual.
- ## **Automatización con Sensores:**
- ## **Eventos de Pluma:** Se habilitó la lectura de sensores internos para detectar estados de apertura/cierre y registrar el motivo de cada movimiento.
- ## **Lectura de TAGs (Beta 2.0):** Se conectaron sensores RFID, logrando la detección vehicular y el accionamiento automatizado en carriles de entrada y salida.
- ## **Librerías de Comunicación:** Para asegurar la estabilidad TCP/IP con los brazos mecánicos, se integraron los SDKs plcommpro.dll y pltcpcomm.dl
## **2.3. Desarrollo de Software y Prototipado**
## El sistema se ha dividido en dos soluciones independientes pero integradas para garantizar la continuidad operativa:

- ## **Sistema Local de Garita (Aplicación Desktop):**
  - ## **Alta Disponibilidad:** Aplicación descargable diseñada para funcionar localmente, permitiendo la operación de la pluma y el cobro manual incluso ante fallos de internet.
  - ## **Evolución:** Se desplegó la Versión 2.0, que incluye la lógica de sensores TAG y el registro de incidencias físicas.
- ## **Plataforma Web de Gestión (Interfaz de Usuario):**
  - ## **Funcionalidad:** Orientada a la comunidad universitaria para la solicitud de permisos, gestión de perfiles (Docentes/Estudiantes) y procesamiento de pagos.
  - ## **Estado Actual:** Auditoría técnica de la visión beta en entorno local para identificar mejoras en el flujo de navegación antes de su despliegue en servidor.
- ## **Stack Tecnológico:** Uso de .NET 8 SDK, SqlClient para persistencia y BCrypt para seguridad de credenciales.

## **3. Glosario Técnico de Bibliotecas**
Para facilitar la comprensión del cliente sobre las tecnologías utilizadas:

|**Biblioteca**|**Función**|
| :- | :- |
|**plcommpro.dll / pltcpcomm.dll**|Protocolos de bajo nivel para comandar el panel de hardware inBio 260 vía red.s |
|**Microsoft.Data.SqlClient**|Permite la conexión y envío de consultas a la base de datos SQL del sistema.|
|**BCrypt.Net**|Sistema de encriptación de grado militar para proteger las contraseñas de los usuarios.|
|**Newtonsoft.Json**|Facilita el intercambio de información estructurada entre la Web y la Aplicación de Garita.|

## **4. Detalles Técnicos para Mantenimiento**
Para futuras referencias de soporte o escalabilidad, se deja constancia de:

- Esquema de Conexión: La lógica de cierre se centraliza en el panel inBio 260. Es vital respetar la configuración de los relevadores establecidos en el diagrama de cableado de esta semana para evitar cortes o fallos de pulso.
- Entorno de Desarrollo: El sistema requiere un entorno compatible con .NET 8 y las librerías DLL mencionadas deben estar registradas en el sistema para la comunicación TCP/IP con los brazos mecánicos.
## **5. Gestión de Riesgos y Contingencias**
- Factor Ambiental: Debido a las fuertes lluvias, se suspendieron las pruebas de hardware en exteriores para proteger la integridad de los equipos electrónicos.
- Mitigación: El equipo aplicó un plan de contingencia pivotando el esfuerzo hacia la refinación de requerimientos y la corrección de errores de lógica en el prototipo (.NET/Razor), optimizando el tiempo de desarrollo en oficina.
## **6. Próximos Pasos (Worklog)**
- **Implementación de Base de Datos:** Creación física de tablas según la infraestructura planteada.
- **Sincronización Web-Garita:** Conectar la información de pagos y horarios desde la plataforma web hacia la aplicación local de garita.
- **Entorno Colaborativo GitHub:** Creación de la organización en GitHub para el control de versiones y documentación bajo metodología **DevOps**.
- **Mejora de Interfaces:** Refinamiento visual de los módulos operativos para su implementación final.

**Nota del Consultor:** El sistema ahora cuenta con una arquitectura resiliente que protege la operación del parqueadero ante contingencias de red, manteniendo la modernidad de una gestión web centralizada.
Descripción de requisitos del software![](Aspose.Words.e3cbbdf5-5095-4777-9964-9a2f509705d0.007.png)
