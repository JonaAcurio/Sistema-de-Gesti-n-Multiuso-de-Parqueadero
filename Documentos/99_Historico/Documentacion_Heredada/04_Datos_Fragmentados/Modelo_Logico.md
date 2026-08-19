# Modelo Logico

## Agregados principales

- OperacionLocal
- CredencialesOperativas
- Sincronizacion
- Observabilidad

## Relaciones

- Usuario 1..n Vehiculo
- Vehiculo 1..n AsociacionOperativa
- TAG 1..n AsociacionOperativa
- PuntoAcceso 1..n EventoAcceso
- DispositivoGarita 1..n EventoSincronizacion

## Claves

- UUID para eventos;
- identificadores locales y externos para entidades sincronizadas;
- version para registros replicados.
