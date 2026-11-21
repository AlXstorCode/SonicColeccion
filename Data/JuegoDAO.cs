using Microsoft.Data.Sqlite;
using SonicColeccion.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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

        public void Actualizar(Juego juego)
        {
            using var conexion = new SqliteConnection(BaseDatos.CadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();

            comando.CommandText = @"
                UPDATE Juegos
                SET Titulo = $titulo, Anno = $anno, Consola = $consola, Estado = $estado, Calificacion = $calificacion
                WHERE Id = $id;";

            comando.Parameters.AddWithValue("$id", juego.Id);
            comando.Parameters.AddWithValue("$titulo", juego.Titulo);
            comando.Parameters.AddWithValue("$anno", juego.Anno);
            comando.Parameters.AddWithValue("$consola", juego.Consola);
            comando.Parameters.AddWithValue("$estado", juego.Estado);
            comando.Parameters.AddWithValue("$calificacion", juego.Calificacion);

            comando.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var conexion = new SqliteConnection(BaseDatos.CadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();

            comando.CommandText = "DELETE FROM Juegos WHERE Id = $id;";
            comando.Parameters.AddWithValue("$id", id);

            comando.ExecuteNonQuery();
        }

        public List<Juego> ObtenerTodos()
        {
            var juegos = new List<Juego>();

            using var conexion = new SqliteConnection(BaseDatos.CadenaConexion);
            conexion.Open();

            using var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT Id, Titulo, Anno, Consola, Estado, Calificacion FROM juegos;";

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                var juego = new Juego(
                    lector.GetInt32(0),
                    lector.GetString(1),
                    lector.GetInt32(2),
                    lector.GetString(3),
                    lector.GetString(4),
                    lector.GetInt32(5)
                    );
                juegos.Add(juego);
            }

            return juegos;
        }
    }
}