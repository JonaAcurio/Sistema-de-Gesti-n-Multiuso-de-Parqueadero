# PR-02 Acceso Vehicular Institucional

Participantes: Vehiculo, InBIO 260, Aplicacion local de garita, Operador de garita.

Flujo principal:
1. Vehiculo llega.
2. Lector detecta TAG.
3. InBIO 260 emite evento.
4. La aplicacion local recibe la lectura.
5. Valida estado local y reglas de acceso.
6. Autoriza o deniega.
7. Registra evento.
8. Abre o mantiene cerrada la barrera.

Alternativas:
- TAG desactivado.
- Lectura duplicada.

Excepciones:
- Error de comunicacion.
- Topologia de salida pendiente de validacion.

Reglas: RN-ACC-001, RN-ACC-002, RN-ACC-003, RN-ACC-006.  
Casos de uso: CU-ACC-001, CU-ACC-002, CU-ACC-004.
