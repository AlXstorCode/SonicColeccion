using System;
using System.Collections.Generic;
using System.Text;

namespace SonicColeccion.Models
{
    public class Juego
    {
        public int Id { get; private set; }
        public string Titulo { get; set; }
        public int Anno { get; set; }
        public string Consola { get; set; }
        public string Estado { get; set; }
        public int Calificacion { get; set; }

        public Juego(string titulo, int anno, string consola, string estado, int calificacion)
        {
            Titulo = titulo;
            Anno = anno;
            Consola = consola;
            Estado = estado;
            Calificacion = calificacion;
        }

        public Juego(int id, string titulo, int anno, string consola, string estado, int calificacion) : this(titulo, anno, consola, estado, calificacion)
        {
            Id = id;
        }

        //Polimorfismo al reemplazar la clase object
        public override string ToString()
        {
            return $"{Titulo} ({Anno} - {Consola} - {Estado} - {Calificacion})";
        }
    }
}