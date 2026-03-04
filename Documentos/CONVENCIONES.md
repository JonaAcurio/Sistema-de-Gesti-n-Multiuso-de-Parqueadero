# Convenciones de Trabajo (Estándar del Equipo)

Para mantener el historial del proyecto organizado y profesional, usaremos un estándar para nombrar nuestros commits y nuestras ramas.

### Estructura de un Commit
Cada vez que guardes código (`git commit`), el mensaje debe seguir este formato: `tipo: descripción breve de lo que se hizo`

**Tipos permitidos:**
* `feat:` (Feature) Para añadir una nueva funcionalidad al sistema.
  * *Ejemplo:* `git commit -m "feat: integrar lectura de TAG RFID por puerto serial"`
* `fix:` Para corregir un error o bug.
  * *Ejemplo:* `git commit -m "fix: corregir cálculo de tarifa por fracción de hora"`
* `docs:` Para cambios exclusivos en la documentación o en el README.
  * *Ejemplo:* `git commit -m "docs: actualizar diagrama MER de la base de datos"`
* `chore:` Para tareas de mantenimiento, configuración o dependencias que no afectan el código del sistema.
  * *Ejemplo:* `git commit -m "chore: añadir archivo .gitignore para .NET y C#"`
* `refactor:` Para mejorar o limpiar código existente sin cambiar su funcionamiento.
  * *Ejemplo:* `git commit -m "refactor: optimizar conexión a PostgreSQL"`

### Estructura de las Ramas (Branches)
Cuando crees una rama nueva (`git checkout -b`), usa los mismos prefijos seguidos de un slash (`/`) y un nombre corto usando guiones:

* **Para funciones nuevas:** `feat/nombre-de-la-funcion`
  * *Ejemplo:* `git checkout -b feat/modulo-sanciones`
* **Para arreglar bugs:** `fix/nombre-del-error`
  * *Ejemplo:* `git checkout -b fix/error-login-admin`
* **Para documentación:** `docs/nombre-documento`
  * *Ejemplo:* `git checkout -b docs/manual-usuario`

**Regla de Oro:** Los nombres de las ramas y los commits deben ser siempre en minúsculas, sin tildes y con guiones en lugar de espacios.