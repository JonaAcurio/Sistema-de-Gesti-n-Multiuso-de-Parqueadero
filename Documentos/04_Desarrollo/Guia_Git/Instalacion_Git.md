# Guía Rápida: Instalación y Configuración de Git en Windows

### Paso 1: Descarga e Instalación
1. Ve a la página oficial de Git y descarga el instalador de **64-bit Git for Windows Setup**.
2. Ejecuta el archivo descargado. Dale "Next" (Siguiente) a las ventanas, pero asegúrate de cambiar estas tres configuraciones clave:
   * **Select Components:** Verifica que la opción "Git Bash Here" esté marcada.
   * **Choosing the default editor:** En el menú desplegable, selecciona "Use Visual Studio Code as Git's default editor".
   * **Adjusting the name of the initial branch:** Selecciona "Override the default branch name for new repositories" y asegúrate de que diga `main`.
3. Termina la instalación dejando el resto de las opciones por defecto.

### Paso 2: Configuración de Identidad
Git requiere registrar tu nombre y correo para firmar los cambios que hagas en el código.
1. Abre el menú de inicio de Windows, busca y abre el programa **Git Bash**.
2. Ejecuta los siguientes comandos uno por uno (presiona Enter después de cada línea). Reemplaza las comillas con tus datos reales:

```bash
git config --global user.name "Tu Nombre y Apellido"
git config --global user.email "tu-correo-de-github@ejemplo.com"
```
*(Importante: Usa exactamente el mismo correo con el que te registraste en GitHub).*

### Paso 3: Vinculación con GitHub
Windows tiene un gestor automático para conectar tu terminal con GitHub de forma segura.
1. En la terminal de Git Bash, ejecuta el comando para clonar el repositorio del proyecto (cambia la URL por la de nuestro repositorio):

```bash
git clone [https://github.com/tu-usuario/SistemaDeGestionMultiusoDeParqueadero.git](https://github.com/tu-usuario/SistemaDeGestionMultiusoDeParqueadero.git)
```
2. Al presionar Enter, aparecerá una ventana emergente del sistema pidiendo iniciar sesión en GitHub.
3. Haz clic en el botón **"Sign in with your browser"** (Iniciar sesión con el navegador).
4. Se abrirá tu navegador web. Autoriza la conexión haciendo clic en el botón verde de aprobación.

¡Listo! El entorno local está configurado y el repositorio está clonado en tu computadora.