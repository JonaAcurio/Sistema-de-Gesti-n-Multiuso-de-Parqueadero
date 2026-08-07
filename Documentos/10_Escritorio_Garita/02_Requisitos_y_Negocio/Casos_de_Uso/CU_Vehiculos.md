# Casos de Uso de Vehiculos

## CU-VEH-001 - Registrar vehiculo

Actor principal: Usuario institucional o operador autorizado.  
Precondiciones: Existe actor habilitado para el registro.  
Flujo:
1. Capturar placa y datos basicos.
2. Validar integridad.
3. Guardar vehiculo.
Resultado: Vehiculo disponible para asociacion.

## CU-VEH-002 - Asociar vehiculo a usuario y TAG

Actor principal: Operador de garita.  
Precondiciones: Existe vehiculo y TAG.  
Flujo:
1. Seleccionar usuario.
2. Seleccionar vehiculo.
3. Seleccionar TAG.
4. Guardar asociacion.
Resultado: Relacion operativa para validacion de acceso.
