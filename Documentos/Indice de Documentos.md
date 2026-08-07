# Índice de Documentos

**Código documental:** CP-IND-001  
**Versión:** 2.0  
**Estado:** Borrador de estabilización documental  
**Fecha:** 2026-07-17  
**Autor:** Codex sobre estructura documental existente  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 2.0 | 2026-07-17 | Incorpora la nueva estructura de gobierno, alcance, stakeholders y control. |
| 1.x | 2026-03 | Índice previo del repositorio. |

## 1. Estructura general

- `00_Gobierno_Documental/`: identidad oficial y registro de decisiones.
- `01_Gestion_Proyecto/`: alcance, control, stakeholders, task list, actas e informes técnicos.
- `02_Requisitos_y_Analisis/`: especificación de requisitos, arquitectura y propuesta de formularios.
- `03_Base_de_Datos/`: esquema SQL de referencia.
- `04_Desarrollo/`: guías y estándares técnicos.
- `05_Operacion/`: reservado para operación futura.
- `99_Historico/`: destino recomendado para documentos sustituidos cuando se formalice la reorganización.

## 2. Documentos vigentes de referencia

### Gobierno documental

- [Identidad y Denominación Oficial](00_Gobierno_Documental/Identidad_y_Denominacion_Oficial.md)
- [Registro de Decisiones](00_Gobierno_Documental/Registro_Decisiones.md)

### Alcance y control

- [Definición del MVP](01_Gestion_Proyecto/Alcance/Definicion_MVP.md)
- [Visión del Sistema Completo](01_Gestion_Proyecto/Alcance/Vision_Sistema_Completo.md)
- [Registro de Inconsistencias Documentales](01_Gestion_Proyecto/Control/Registro_Inconsistencias_Documentales.md)
- [Preguntas Pendientes para PUCESA](01_Gestion_Proyecto/Control/Preguntas_Pendientes_PUCESA.md)
- [Task List de Estabilización](01_Gestion_Proyecto/Task_List.md)

### Stakeholders

- [Registro de Stakeholders](01_Gestion_Proyecto/Stakeholders/Registro_Stakeholders.md)
- [Matriz RACI Inicial](01_Gestion_Proyecto/Stakeholders/Matriz_RACI_Inicial.md)

### Requisitos y análisis

- [Especificación de Requisitos de Software](02_Requisitos_y_Analisis/Plantillas/Plantilla_IEEE830_Parqueadero.md)
- [Propuesta de Formularios](02_Requisitos_y_Analisis/UX_UI/Propuesta_Formularios.md)
- [Análisis de Lógica de Negocio](02_Requisitos_y_Analisis/Arquitectura/Analisis_Logica_Negocio.md)
- [Informe de Arquitectura (PDF)](02_Requisitos_y_Analisis/Arquitectura/Informe_Arquitectura_Sistema.pdf)

### Base de datos

- [Esquema SQL de referencia](03_Base_de_Datos/Esquema/dbo.sql)

## 3. Observaciones de trazabilidad

- Existen rutas duplicadas entre `Actas/`, `Actas_de_Reuniones/` e `Informes_Tecnicos/`.
- Mientras no se ejecute la depuración histórica completa, debe privilegiarse la lectura de los documentos de gobierno, alcance y control como fuente de verdad.
- Los documentos históricos no deben eliminarse; deben reubicarse controladamente cuando el equipo lo decida.
