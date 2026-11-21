using Microsoft.Data.Sqlite;
using SonicColeccion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicColeccion.Data
{
    public class JuegoDAO
    {
        public void Insertar(Juego juego)
        {
            using var conexion = new SqliteConnection(BaseDatos.CadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Juegos (Titulo, Anno, Consola, Estado, Calificacion)
                VALUES ($titulo, $anno, $consola, $estado, $calificacion);";

            comando.Parameters.AddWithValue("$titulo", juego.Titulo);
            comando.Parameters.AddWithValue("$anno", juego.Anno);
            comando.Parameters.AddWithValue("$consola", juego.Consola);
            comando.Parameters.AddWithValue("$estado", juego.Estado);
            comando.Parameters.AddWithValue("$calificacion", juego.Calificacion);

            comando.ExecuteNonQuery();
        }
    }
}