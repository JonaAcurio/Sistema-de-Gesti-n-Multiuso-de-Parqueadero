# Estrategia de Operacion Offline

**Codigo documental:** CP-ARQ-305  
**Version:** 1.0  
**Fecha:** 2026-07-18

## Objetivo

Permitir que la garita siga operando si falla internet, la API central o servicios institucionales no indispensables para la decision local.

## Datos minimos locales

- usuarios operativos minimos;
- vehiculos asociados;
- TAG autorizados;
- estados y vigencias;
- configuracion del controlador;
- operadores habilitados;
- eventos pendientes de sincronizar.

## Fuente de verdad

- central: datos administrativos;
- local: operacion temporal y eventos originados en garita hasta confirmacion central.

## Reglas

1. Todo acceso se registra localmente antes de considerarse finalizado.
2. La garita no espera respuesta central para abrir o denegar.
3. Los cambios administrativos se aplican localmente por sincronizacion controlada.
4. Toda reconexion dispara evaluacion de cola pendiente.

## Escenarios de falla

- internet caido con controlador disponible;
- API central caida con red local operativa;
- reinicio del equipo local con cola pendiente;
- lectura durante reconexion;
- duplicado por reenvio.

## Criterio de salida de contingencia

La garita sale de modo contingencia cuando:

- recupera conectividad suficiente hacia la API;
- reintenta la cola;
- confirma eventos pendientes o marca errores permanentes.
