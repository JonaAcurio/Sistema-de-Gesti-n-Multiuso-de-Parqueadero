# Guía de Estilo y Redacción para Informes Técnicos de Ingeniería

A diferencia de las "Actas de Avance" (que están diseñadas para informar rápidamente a gerentes o clientes sobre el progreso semanal), un **Informe Técnico** es un documento de arquitectura y referencia estricta. Su público objetivo son otros ingenieros, desarrolladores, administradores de bases de datos (DBAs) y arquitectos de software que, en un futuro, necesiten mantener, modificar o escalar el sistema sin hacer preguntas a los creadores originales.

El objetivo principal es la **precisión, la objetividad y la reproducibilidad**.

---

## 1. Tono y Lenguaje (La Regla de la Impersonalidad)
El documento debe escribirse en tercera persona del singular (forma impersonal) o pasiva. Elimina cualquier rastro de opinión personal, emociones o lenguaje coloquial.

*   ❌ **Incorrecto (Subjetivo/Coloquial):** "Ayer arreglamos la base de datos porque estaba súper lenta y le metimos unas tablas nuevas."
*   ✅ **Correcto (Impersonal/Técnico):** "Se optimizó la base de datos mediante la normalización del modelo relacional, reduciendo los tiempos de consulta."
*   ❌ **Incorrecto (Primera persona):** "Yo creé un script para subir los datos."
*   ✅ **Correcto (Pasivo):** "Se desarrolló y ejecutó un script de poblamiento de datos (`Data Seeding`)."

## 2. Precisión Semántica y Uso de Jerga Estándar
Usa los términos exactos de la industria del software. No uses sinónimos para el mismo concepto técnico para evitar ambigüedades.

*   Si hablas de *bases de datos*, usa términos como: Entidad, Relación, Constraint, Integridad Referencial, DDL, DML, Transacción, Script, Instancia, Backup, Normalización.
*   Si hablas de *código*: Refactorización, Endpoint, Clase, Método, Instanciación, Despliegue, Entorno (Local/Staging/Producción).
*   **Ejemplo:** En lugar de "comprobar que el mail esté bien escrito", usa "Validación de formato mediante restricciones (*Constraints*) a nivel de motor".

## 3. Estructura Obligatoria de un Informe Técnico
Un buen informe técnico no se lee de principio a fin como un libro; se "escanea" buscando información específica. Debe tener esta estructura:

### A. Metadatos del Documento (El Encabezado)
Todo informe técnico debe iniciar con su metadata clara:
*   **Título Descriptivo:** Ej. "INFORME TÉCNICO: ARQUITECTURA DB V1.0"
*   **Proyecto y Versión:** Qué sistema cubre y qué versión de la arquitectura representa.
*   **Fecha de emisión:** Cuándo se consolidó el informe.
*   **Stack Tecnológico:** Lenguajes, Motores o Frameworks con sus versiones exactas (ej. SQL Server 22.3.2).

### B. Resumen Arquitectónico (Abstract)
Un párrafo que explica *qué* cubre el documento y *por qué* existe.

### C. Mapeo o Diccionario de Componentes
Agrupa la información lógicamente, **no alfabéticamente**. Por ejemplo, para una base de datos, no listes todas las tablas juntas; agrúpalas por "Dominio de Negocio" (Seguridad, Financiero, Operativo, etc.). Describe *qué hace* cada pieza y *con qué se comunica*.

### D. Procedimientos y Despliegues (Reproducibilidad)
Explica cómo se instalan, levantan o respaldan los componentes. Menciona artefactos específicos (nombres de archivos `.bak` o `.sql`) para que otro programador sepa exactamente qué buscar en el repositorio.

### E. Deuda Técnica y Hoja de Ruta (Next Steps)
En ingeniería, lo pendiente no es "lo que no acabamos hoy". Es "Deuda Técnica" o "Features del próximo Sprint". Se documenta como tareas técnicas formales pendientes por desarrollar.

---

## 4. Mejores Prácticas de Formato (Markdown)

1.  **Bloques de Código (`code`):** Siempre que menciones el nombre de una tabla, columna, variable, archivo o comando, enciérralo en acentos graves (ej. la tabla `Usuarios` o el archivo `backup.bak`). Esto resalta el elemento técnico.
2.  **Viñetas y Subtítulos numéricos (ej. 1.2.1):** Usa jerarquía numérica profunda para hacer el documento indexable. Si alguien necesita ver los roles, puede ir directamente a "Sección 2.1. Roles".
3.  **Listas y Tablas:** Evita los bloques de texto largos. Si tienes que comparar componentes o listar atributos, haz una tabla o una lista de viñetas.

---

## 5. Checklist de Verificación (Antes de Guardar)

Antes de dar por terminado un Informe Técnico, compruébalo contra estas 4 preguntas de control:
*   [ ] **Inmortalidad:** Si el equipo actual de desarrollo renuncia mañana, ¿un ingeniero nuevo podría entender la estructura solo leyendo este documento?
*   [ ] **Precisión:** ¿Las versiones de las herramientas (ej. "SQL Server 22.3.2") están documentadas de manera exacta?
*   [ ] **Aislamiento de Culpas:** ¿El texto es puramente descriptivo y técnico, libre de excusas o señalamientos personales sobre errores pasados?
*   [ ] **Trazabilidad:** ¿Menciona los nombres exactos de los archivos clave (scripts, backups, llaves primarias)?
