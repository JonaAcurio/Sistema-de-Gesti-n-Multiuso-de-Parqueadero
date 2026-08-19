# Análisis de Lógica de Negocio: Diagramas de Secuencia

**Código documental:** CP-ARQ-001  
**Versión:** 1.1  
**Estado:** Documento de apoyo conceptual sujeto a estabilización  
**Fecha:** 2026-07-17  
**Autor:** Equipo del proyecto; actualización de contexto por Codex  
**Revisores:** Equipo del proyecto; Pendiente de validación por PUCESA  
**Aprobador:** Responsable institucional por designar

## Historial de cambios

| Versión | Fecha | Descripción |
| --- | --- | --- |
| 1.1 | 2026-07-17 | Agrega contexto de estabilización y separación entre visión futura y MVP. |
| 1.0 | 2026-03 | Versión inicial del documento. |

Este documento centraliza flujos de interacción conceptuales para requerimientos del sistema completo. No debe interpretarse como evidencia de implementación ni como definición formal del MVP vigente.

> **Nota de estabilización**
>
> Los flujos de Microsoft SSO y demás capacidades institucionales descritas aquí pertenecen a la visión del sistema completo o a propuestas previas, salvo que otro documento de gobierno o alcance las clasifique expresamente como parte del MVP.

---

## 🔐 RF-05: Autenticación Microsoft SSO
**Propósito:** Garantizar el acceso seguro de usuarios institucionales mediante el proveedor de identidad de Microsoft.

> [!NOTE]
> El flujo incluye la validación del token JWT, la búsqueda del usuario en la base de datos local y la creación automática de perfiles para nuevos usuarios.

---

## 🚗 RF-06: Registro de Vehículos
**Propósito:** Vincular placas vehiculares a propietarios institucionales asegurando la unicidad en el sistema.

---

## ⚠️ RF-07: Restricción de Flota por Usuario
**Propósito:** Control lógico para impedir que usuarios estándar (Docentes/Estudiantes) registren más de 2 vehículos activos.

---

## 🎫 RF-08: Generación de Solicitud de TAG
**Propósito:** Flujo de pedido de credenciales rídidas, vinculando al usuario con su vehículo y parqueadero asignado.

> [!IMPORTANT]
> Las solicitudes generadas quedan en estado "PENDIENTE" y se reflejan automáticamente en el Dashboard del departamento Financiero para su validación de pago.
