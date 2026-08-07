# PR-07 Operacion Offline

Participantes: Aplicacion local, Operador de garita, Soporte tecnico.

Flujo principal:
1. Se detecta indisponibilidad de servicios centrales.
2. La aplicacion mantiene operacion con datos locales.
3. Sigue registrando accesos y eventos.
4. Marca eventos pendientes de sincronizacion.

Alternativas:
- Operacion limitada solo a acceso.

Excepciones:
- Almacenamiento local no disponible.

Reglas: RN-SIN-001, RN-AUD-002.  
Casos de uso: CU-ACC-006.
