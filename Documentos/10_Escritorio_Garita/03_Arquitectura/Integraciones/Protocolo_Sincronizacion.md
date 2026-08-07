# Protocolo de Sincronizacion

1. La garita genera evento con UUID.
2. Persiste el evento localmente.
3. Marca `PENDIENTE`.
4. Intenta envio autenticado a `/sync/eventos`.
5. Si el servidor responde aceptacion, marca `CONFIRMADO`.
6. Si falla, pasa a `ERROR_REINTENTABLE` o `ERROR_PERMANENTE`.
7. La garita consulta `/sync/cambios` para novedades administrativas relevantes.
