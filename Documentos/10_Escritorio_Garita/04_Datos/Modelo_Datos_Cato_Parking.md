# Modelo de Datos Cato Parking

**Código documental:** CP-DAT-001 consolidado
**Versión:** 2.0
**Estado:** Modelo conceptual y lógico para validación
**Fecha:** 2026-08-18

## Alcance y fuente de verdad

Este documento consolida el modelo conceptual, la proyección local, el modelo lógico, el diccionario, los estados, las reglas de integridad y la estrategia de migraciones que estaban fragmentados en `04_Datos/`. Describe la documentación del escritorio de garita; no sustituye decisiones de la plataforma central ni constituye evidencia de implementación.

La plataforma central es dueña de la dimensión administrativa. La garita mantiene una proyección operativa mínima y temporal de las entidades necesarias para decidir, registrar y sincronizar la operación local.

## Entidades conceptuales

- Dispositivo de Garita
- Punto de Acceso
- Operador
- Usuario
- Vehículo
- TAG
- Asociación Operativa
- Evento de Acceso
- Evento Técnico
- Evento de Sincronización
- Configuración Local

## Modelo central visto desde garita

La garita no modela internamente toda la base central. Consume, como mínimo operativo documentado:

- usuario operativo;
- vehículo;
- TAG;
- asociación vigente;
- configuración aplicable;
- operador habilitado.

## Conjuntos de datos locales

- `operadores_locales`
- `usuarios_operativos`
- `vehiculos_operativos`
- `tags_operativos`
- `asociaciones_operativas`
- `puntos_acceso`
- `eventos_acceso`
- `eventos_tecnicos`
- `cola_sincronizacion`
- `configuracion_local`

## Agregados y relaciones

Agregados principales: `OperacionLocal`, `CredencialesOperativas`, `Sincronizacion`, `Observabilidad`.

- Usuario 1..n Vehículo.
- Vehículo 1..n AsociaciónOperativa.
- TAG 1..n AsociaciónOperativa.
- PuntoAcceso 1..n EventoAcceso.
- DispositivoGarita 1..n EventoSincronizacion.

Claves y versionado:

- UUID para eventos;
- identificadores locales y externos para entidades sincronizadas;
- versión para registros replicados.

## Diccionario mínimo

| Campo | Descripción |
| --- | --- |
| `evento_id` | UUID del evento generado en garita |
| `dispositivo_id` | Identificador de la garita |
| `tag_codigo` | Identificador leído del TAG |
| `usuario_ref` | Referencia del usuario operativo |
| `vehiculo_ref` | Referencia del vehículo operativo |
| `punto_acceso` | Entrada o salida lógica |
| `resultado_acceso` | Autorizado o denegado |
| `estado_sync` | Estado de la cola local |
| `fecha_evento` | Marca temporal local del evento |

## Catálogo de estados

**TAG:** `TAG_ACTIVO`, `TAG_SUSPENDIDO`, `TAG_PERDIDO`, `TAG_DANADO`, `TAG_BAJA`.

**Sincronización:** `PENDIENTE`, `ENVIANDO`, `CONFIRMADO`, `ERROR_REINTENTABLE`, `ERROR_PERMANENTE`, `CONFLICTO`.

**Conexión:** `DESCONECTADO`, `CONECTANDO`, `CONECTADO`, `DEGRADADO`, `RECONECTANDO`, `ERROR`.

## Reglas de integridad documentadas

1. Un `evento_id` no puede repetirse localmente.
2. Un TAG operativo no puede existir duplicado.
3. Una placa no puede existir duplicada en el contexto operativo.
4. Un usuario no puede superar 2 vehículos activos.
5. Un evento confirmado no vuelve a cola pendiente.
6. Toda apertura manual debe tener motivo.

## Migraciones y diagramas

- Aprobar primero el modelo lógico.
- Versionar cambios de base local por esquema.
- No modificar manualmente estructuras en producción sin script controlado.
- Mantener compatibilidad con cola pendiente durante cambios.
- Separar migraciones locales y centrales.
- Los diagramas deben derivarse de este modelo cuando exista materialización aprobada; no se considera evidencia una carpeta reservada sin diagramas.

## Pendientes

Quedan pendientes el modelo físico aprobado, la política de sincronización definitiva, la política de retención de datos personales, el RPO/RTO institucional y la decisión sobre la relación entre los artefactos SQL heredados y el modelo objetivo. El archivo SQL existente se conserva como artefacto técnico no normativo y no se usa para validar requisitos.
