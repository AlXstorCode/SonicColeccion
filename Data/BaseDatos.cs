using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace SonicColeccion.Data
{
    public static class BaseDatos
    {
        private static readonly string ruta = Path.Combine(AppContext.BaseDirectory, "sonic.db");
        public static string CadenaConexion => $"Data Source={ruta}";

        public static void Inicializar()
        {
            using var conexion = new SqliteConnection(CadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"
                CREATE TABLE IF NOT EXISTS Juegos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL,
                    Anno INTEGER NOT NULL,
                    Consola TEXT NOT NULL,
                    Estado TEXT NOT NULL,
                    Calificacion INTEGER NOT NULL
                 );";
            comando.ExecuteNonQuery();
        }
    }
}