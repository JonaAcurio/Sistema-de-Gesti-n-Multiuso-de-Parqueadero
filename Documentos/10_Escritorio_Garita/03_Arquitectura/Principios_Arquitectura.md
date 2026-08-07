# Principios de Arquitectura

**Codigo documental:** CP-ARQ-302  
**Version:** 1.0  
**Estado:** Vigente para Fase 3  
**Fecha:** 2026-07-18

1. La garita debe seguir operando localmente si falla internet.
2. Ninguna lectura valida debe perderse por una caida temporal de red.
3. La interfaz no decide reglas de acceso.
4. Toda integracion externa debe pasar por adaptadores.
5. La sincronizacion debe ser idempotente.
6. La configuracion debe ser externa y auditable.
7. Los datos locales deben ser minimos y suficientes.
8. Los logs tecnicos, operativos y la auditoria no se mezclan.
9. La seguridad local debe asumir posible acceso fisico al equipo.
10. La arquitectura debe poder extenderse a multiples garitas sin rehacerse.
