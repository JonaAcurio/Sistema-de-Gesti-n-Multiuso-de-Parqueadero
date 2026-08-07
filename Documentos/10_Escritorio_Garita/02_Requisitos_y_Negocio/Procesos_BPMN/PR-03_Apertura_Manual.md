# PR-03 Apertura Manual

Participantes: Operador de garita, Seguridad, Aplicacion local, InBIO 260.

Flujo principal:
1. El operador solicita apertura manual.
2. El sistema verifica permiso.
3. Exige motivo obligatorio.
4. Registra la justificacion.
5. Envia la orden.
6. Registra actor, acceso, fecha y hora.

Alternativas:
- Seguridad ejecuta la accion.

Excepciones:
- Usuario sin permiso.
- Motivo ausente.
- Falla de comunicacion.

Reglas: RN-ACC-005, RN-AUD-001.  
Casos de uso: CU-ACC-003.
