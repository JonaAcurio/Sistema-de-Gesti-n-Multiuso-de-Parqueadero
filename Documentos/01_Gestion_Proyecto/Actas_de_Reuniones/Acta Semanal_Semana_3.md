# Acta de Avance Semanal: Proyecto SGP PUCESA

**Semana:** 3
**Estado del Proyecto:** Prototipo Funcional al 60% (Sistema de Escritorio)
**Responsables:** Equipo de Desarrollo SGP

## 1. Resumen Ejecutivo
Durante la tercera semana de desarrollo, se realizó un pulido significativo al prototipo funcional de escritorio, alcanzando un progreso del 60%. Las actividades principales se centraron en las pruebas de campo en la garita para la detección de errores en tiempo real, la capacitación inicial al personal de operación y las reuniones estratégicas con el equipo de la PUCESA. Además, se ejecutó una investigación de campo en el parqueadero del coliseo con miras a la expansión e integración de un ecosistema global.

## 2. Desarrollo y Pruebas del Prototipo
- **Avance del Prototipo:** Se aplicaron mejoras y pulido al sistema de escritorio, consolidando una funcionalidad operativa del 60% respecto al producto final esperado.
- **Pruebas de Campo (Garita):** Se ejecutaron pruebas in situ para validar el comportamiento del sistema bajo condiciones reales de operación.
- **Resolución de Errores Lógicos (Lectura de Tags):** Durante las pruebas, se detectó una vulnerabilidad en las validaciones direccionales de los Tags RFID. Específicamente, si un tag era detectado en el rango del lector antes del ingreso del vehículo (ocurrió al realizar la prueba acercando el tag manualmente), el sistema marcaba erróneamente un evento de "salida" al no validar correctamente el estado previo (dentro/fuera) del tag. El error de validación ya ha sido identificado para su corrección.

## 3. Experiencia de Usuario y Capacitación (Usabilidad)
- **Formación Operativa:** Se impartió capacitación a un miembro del personal de la garita sobre el uso del nuevo sistema de escritorio.
- **Adaptaciones Ergonómicas:** Mediante la observación directa de la interacción del guardia con la interfaz, se tomaron notas y se aplicaron ligeras adaptaciones de diseño, logrando que el software sea más accesible.
- **Evaluación de Usabilidad:** Aunque se concluye que será necesaria una capacitación más profunda para todo el equipo operativo en el futuro, el nivel de usabilidad de la interfaz actual permite al operador administrar el sistema de forma independiente y sin asistencia continua.

## 4. Expansión e Infraestructura (Fase Coliseo)
- **Investigación de Campo:** Se visitaron las instalaciones del garaje del coliseo con el objetivo de evaluar la factibilidad de su integración al sistema centralizado.
- **Auditoría Técnica:** Se verificó que el parqueadero cuenta con infraestructura antigua y dependía de un sistema completamente obsoleto.
- **Recomendación de Ingeniería:** Se sugirió formalmente la renovación total de la infraestructura en dicho sector para garantizar la compatibilidad tecnológica.

## 5. Gestión de Stakeholders y Decisiones Estratégicas
- **Presentación de Avances a PUCESA:** Se sostuvo una reunión formal con el equipo de la PUCE para realizar una demostración práctica de la versión Beta (60%), exhibiendo las funcionalidades operativas en tiempo real.
- **Decisión sobre el Coliseo:** En la misma reunión, se expusieron los hallazgos de la auditoría técnica. Por consenso, se aprobó la conclusión de adquirir nuevo hardware para el garaje del coliseo, conectándolo al sistema principal para conformar un **ecosistema global unificado**.

## 6. Siguientes Pasos (Pendientes)
- **Refactorización de Lógica RFID:** Corregir la validación de estados "dentro/fuera" en el cruce de tags para prevenir registros de salida prematuros.
- **Gestión de Compras (Hardware):** Iniciar la coordinación técnica para la compra de los nuevos equipos destinados al coliseo.
- **Plan de Capacitación Continua:** Diseñar y programar sesiones de instrucción más completas para el resto de los operadores de la garita.
- **Desarrollo:** Retomar la programación de los módulos restantes para avanzar el 40% pendiente del aplicativo de escritorio.
