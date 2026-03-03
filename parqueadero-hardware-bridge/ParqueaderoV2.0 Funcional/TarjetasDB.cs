using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace InterfazParqueadero
{
    /// <summary>
    /// Gestión de base de datos local de tarjetas RFID autorizadas
    /// Almacenamiento en archivo JSON
    /// </summary>
    public class TarjetasDB
    {
        private const string ARCHIVO_DB = "tarjetas_autorizadas.json";
        private List<TarjetaRFID> tarjetas = new List<TarjetaRFID>();

        public event Action? OnCambiosGuardados;

        public TarjetasDB()
        {
            CargarDesdeArchivo();
        }

        /// <summary>
        /// Obtener todas las tarjetas registradas
        /// </summary>
        public List<TarjetaRFID> ObtenerTodas()
        {
            return new List<TarjetaRFID>(tarjetas);
        }

        /// <summary>
        /// Verificar si una tarjeta está autorizada
        /// </summary>
        public bool EstaAutorizada(string numeroTarjeta)
        {
            return tarjetas.Any(t => t.Numero == numeroTarjeta && t.Habilitada);
        }

        /// <summary>
        /// Obtener información de una tarjeta
        /// </summary>
        public TarjetaRFID? ObtenerTarjeta(string numeroTarjeta)
        {
            return tarjetas.FirstOrDefault(t => t.Numero == numeroTarjeta);
        }

        /// <summary>
        /// Agregar nueva tarjeta
        /// </summary>
        public bool AgregarTarjeta(string numeroTarjeta, string nombreUsuario, string? observaciones = null)
        {
            // Validar que no exista
            if (tarjetas.Any(t => t.Numero == numeroTarjeta))
            {
                return false; // Ya existe
            }

            var nueva = new TarjetaRFID
            {
                Numero = numeroTarjeta,
                NombreUsuario = nombreUsuario,
                Observaciones = observaciones ?? "",
                FechaRegistro = DateTime.Now,
                Habilitada = true
            };

            tarjetas.Add(nueva);
            GuardarEnArchivo();
            return true;
        }

        /// <summary>
        /// Eliminar tarjeta
        /// </summary>
        public bool EliminarTarjeta(string numeroTarjeta)
        {
            var tarjeta = tarjetas.FirstOrDefault(t => t.Numero == numeroTarjeta);
            if (tarjeta == null) return false;

            tarjetas.Remove(tarjeta);
            GuardarEnArchivo();
            return true;
        }

        /// <summary>
        /// Habilitar o deshabilitar tarjeta
        /// </summary>
        public bool CambiarEstado(string numeroTarjeta, bool habilitada)
        {
            var tarjeta = tarjetas.FirstOrDefault(t => t.Numero == numeroTarjeta);
            if (tarjeta == null) return false;

            tarjeta.Habilitada = habilitada;
            GuardarEnArchivo();
            return true;
        }

        /// <summary>
        /// Actualizar datos de tarjeta
        /// </summary>
        public bool ActualizarTarjeta(string numeroTarjeta, string nombreUsuario, string observaciones)
        {
            var tarjeta = tarjetas.FirstOrDefault(t => t.Numero == numeroTarjeta);
            if (tarjeta == null) return false;

            tarjeta.NombreUsuario = nombreUsuario;
            tarjeta.Observaciones = observaciones;
            GuardarEnArchivo();
            return true;
        }

        /// <summary>
        /// Guardar en archivo JSON
        /// </summary>
        private void GuardarEnArchivo()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(tarjetas, options);
                File.WriteAllText(ARCHIVO_DB, json);
                OnCambiosGuardados?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar tarjetas: {ex.Message}");
            }
        }

        /// <summary>
        /// Cargar desde archivo JSON
        /// </summary>
        private void CargarDesdeArchivo()
        {
            try
            {
                if (File.Exists(ARCHIVO_DB))
                {
                    string json = File.ReadAllText(ARCHIVO_DB);
                    var cargadas = JsonSerializer.Deserialize<List<TarjetaRFID>>(json);
                    if (cargadas != null)
                    {
                        tarjetas = cargadas;
                    }
                }
                else
                {
                    // Crear archivo vacío inicial
                    tarjetas = new List<TarjetaRFID>();
                    GuardarEnArchivo();
                }
            }
            catch (Exception)
            {
                // Si hay error, iniciar con lista vacía
                tarjetas = new List<TarjetaRFID>();
            }
        }

        /// <summary>
        /// Obtener estadísticas
        /// </summary>
        public (int total, int habilitadas, int deshabilitadas) ObtenerEstadisticas()
        {
            int total = tarjetas.Count;
            int habilitadas = tarjetas.Count(t => t.Habilitada);
            int deshabilitadas = total - habilitadas;
            return (total, habilitadas, deshabilitadas);
        }
    }

    /// <summary>
    /// Modelo de datos de tarjeta RFID
    /// </summary>
    public class TarjetaRFID
    {
        public string Numero { get; set; } = "";
        public string NombreUsuario { get; set; } = "";
        public string Observaciones { get; set; } = "";
        public DateTime FechaRegistro { get; set; }
        public bool Habilitada { get; set; }
    }
}
