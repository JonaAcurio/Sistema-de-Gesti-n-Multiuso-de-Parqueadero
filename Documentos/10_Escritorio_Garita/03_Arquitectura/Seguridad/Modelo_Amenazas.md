# Modelo de Amenazas

| Amenaza | Impacto | Mitigacion inicial |
| --- | --- | --- |
| Clonacion o prestamo de TAG | Accesos indebidos | trazabilidad, desactivacion central, auditoria |
| Apertura manual abusiva | Fraude operativo | motivo obligatorio y auditoria |
| Manipulacion de datos locales | Perdida de integridad | base protegida y controles locales |
| Cambio de reloj del equipo | Secuencia incorrecta | registrar origen y detectar desfase |
| Duplicacion de eventos | Doble registro | UUID e idempotencia |
| Credenciales expuestas | Compromiso de API | cifrado y rotacion |
| DLL o controlador inestable | Caida operativa | reconexion y aislamiento del adaptador |
