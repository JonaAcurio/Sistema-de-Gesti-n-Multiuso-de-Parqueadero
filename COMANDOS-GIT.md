# Hoja de Trucos: Comandos Básicos de Git

Esta guía contiene los comandos del día a día necesarios para trabajar en el proyecto sin sobrescribir el trabajo de los demás.

### 1. El Flujo de Trabajo Diario
Estos son los comandos que usarás cada vez que te sientes a programar y termines una tarea.

* **Ver el estado actual de tus archivos:** Muestra qué archivos han sido modificados, cuáles están listos para guardarse y en qué rama estás.
  ```bash
  git status
  ```
* **Preparar archivos para guardar (Staging):** Agrega los cambios que hiciste para el próximo "guardado".
  ```bash
  git add nombre-del-archivo.cs # Agrega un archivo específico
  git add .                     # Agrega TODOS los archivos modificados
  ```
* **Guardar los cambios localmente (Commit):** Crea un punto de control con los archivos que preparaste en el paso anterior. Siempre usa un mensaje descriptivo.
  ```bash
  git commit -m "feat: agregar lógica de cobro por fracción de hora"
  ```
* **Subir tus cambios a GitHub (Push):** Envía tus commits locales al servidor para que el resto del equipo pueda verlos.
  ```bash
  git push origin nombre-de-tu-rama
  ```

### 2. Trabajo en Equipo (Sincronización)
Antes de empezar a programar cada día, debes asegurarte de tener la última versión del código que hicieron tus compañeros.

* **Descargar los últimos cambios del servidor:** Trae el código nuevo de GitHub y lo fusiona con el tuyo. (Haz esto siempre en la rama main antes de crear una nueva).
  ```bash
  git pull origin main
  ```

### 3. Manejo de Ramas (Branches)
**Regla de oro:** Nunca trabajamos directamente en `main`. Cada nueva funcionalidad o corrección se hace en su propia rama.

* **Crear una rama nueva y moverte a ella:** Ideal para empezar una nueva tarea.
  ```bash
  git checkout -b nombre-de-la-rama
  ```
  *(Ejemplo: `git checkout -b feat/conexion-rfid`)*
* **Ver todas las ramas:** Te muestra las ramas locales. La que tiene un asterisco (*) es en la que estás actualmente.
  ```bash
  git branch
  ```
* **Cambiar de una rama a otra:** Útil si necesitas revisar el código de main o cambiar de tarea. (Asegúrate de hacer commit a tus cambios antes de saltar).
  ```bash
  git checkout nombre-de-la-rama
  ```
* **Borrar una rama local (cuando ya terminaste):** Mantén tu entorno limpio borrando las ramas que ya se fusionaron en GitHub.
  ```bash
  git branch -d nombre-de-la-rama
  ```

### 4. Casos de Emergencia (Me equivoqué, ¿qué hago?)
* **Deshacer cambios en un archivo antes de hacer commit:** Si editaste un archivo, lo rompiste y quieres volver a la última versión guardada en Git.
  ```bash
  git restore nombre-del-archivo.cs
  ```
* **Cambiar el mensaje del último commit:** Si te equivocaste escribiendo el mensaje y aún no has hecho git push.
  ```bash
  git commit --amend -m "Nuevo mensaje corregido"
  ```