# Casos de Uso de TAG

## CU-TAG-001 - Registrar TAG

Actor principal: Operador de garita.  
Precondiciones: El TAG no existe.  
Flujo:
1. Capturar identificador.
2. Asociar usuario y vehiculo.
3. Guardar estado inicial.
Resultado: TAG habilitado para operacion.

## CU-TAG-002 - Activar o desactivar TAG

Actor principal: Operador de garita.  
Precondiciones: El TAG existe.  
Flujo:
1. Buscar TAG.
2. Cambiar estado.
3. Confirmar registro.
Resultado: Estado actualizado con historial.

## CU-TAG-003 - Reponer TAG por perdida

Actor principal: Administrador funcional.  
Precondiciones: Existe un TAG anterior reportado.  
Flujo:
1. Desactivar TAG perdido.
2. Registrar nuevo TAG.
3. Reasociar al usuario y vehiculo.
Resultado: Nueva credencial operativa.
