# PR-08 Sincronizacion Posterior

Participantes: Aplicacion local, Servicio de sincronizacion, Plataforma web, Soporte tecnico.

Flujo principal:
1. Se restablece conectividad.
2. El sistema prepara eventos pendientes.
3. Envia datos al servicio central.
4. Confirma recepcion.
5. Marca eventos sincronizados.

Alternativas:
- Reintento parcial.

Excepciones:
- Conflicto de datos.
- Reconexion fallida.

Reglas: RN-GAR-003.  
Casos de uso: CU-ACC-005, CU-ACC-006.
