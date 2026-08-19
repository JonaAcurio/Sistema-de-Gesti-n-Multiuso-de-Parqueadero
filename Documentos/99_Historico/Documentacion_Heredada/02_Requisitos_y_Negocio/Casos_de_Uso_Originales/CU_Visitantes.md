# Casos de Uso de Visitantes

## CU-VIS-001 - Registrar visitante

Actor principal: Operador de garita.  
Precondiciones: Reglas de visitantes definidas.  
Flujo:
1. Capturar identificacion y vehiculo.
2. Registrar motivo y anfitrion.
3. Guardar visita.
Resultado: Visita lista para autorizacion.

## CU-VIS-002 - Autorizar salida de visitante

Actor principal: Operador de garita.  
Precondiciones: Existe visita activa.  
Flujo:
1. Consultar visita.
2. Validar permanencia o pago si aplica.
3. Registrar salida.
Resultado: Cierre de visita auditable.
