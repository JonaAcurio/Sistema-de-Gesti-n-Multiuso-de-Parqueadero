# Modelo de Seguridad del Escritorio de Garita

**Codigo documental:** CP-SEG-301  
**Version:** 1.0  
**Fecha:** 2026-07-18

## Identidad

- operador local;
- soporte tecnico;
- cuenta tecnica del dispositivo;
- plataforma central;
- Microsoft SSO como proveedor externo de la plataforma central.

## Autorizacion

- minimo privilegio;
- separacion entre operacion, soporte y configuracion;
- trazabilidad de acciones manuales.

## Seguridad local

- credenciales cifradas;
- configuracion protegida;
- bitacora de cambios;
- bloqueo del equipo cuando no esta en uso.

## Comunicacion

- HTTPS hacia la API;
- validacion de certificado;
- autenticacion por dispositivo;
- rotacion de secretos cuando aplique.
