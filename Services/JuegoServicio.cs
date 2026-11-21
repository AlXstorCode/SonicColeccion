using System;
using System.Collections.Generic;
using SonicColeccion.Data;
using SonicColeccion.Models;

namespace SonicColeccion.Services
{
    public class JuegoServicio
    {
        private readonly JuegoDAO dao = new JuegoDAO();

        private void Validar(Juego juego)
        {
            if (string.IsNullOrWhiteSpace(juego.Titulo))
                throw new ArgumentException("El titulo no puede estar vacío");
            if (string.IsNullOrWhiteSpace(juego.Consola))
                throw new ArgumentException("La consola no puede estar vacía");
            if (string.IsNullOrWhiteSpace(juego.Estado))
                throw new ArgumentException("El estado no puede estar vacío");
            if (juego.Anno < 1991 || juego.Anno > DateTime.Now.Year)
                throw new ArgumentException($"El año debe estar entre 1991 y {DateTime.Now.Year}.");
            if (juego.Calificacion < 1 || juego.Calificacion > 10)
                throw new ArgumentException("La calificación no puede ser menor a 1 ni mayor a 10.");
        }

        public void Registrar(Juego juego)
        {
            Validar(juego);
            dao.Insertar(juego);
        }

        public List<Juego> Listar()
        {
            return dao.ObtenerTodos();
        }

        public void Modificar(Juego juego)
        {
            Validar(juego);
            dao.Actualizar(juego);
        }

        public void Borrar(int id)
        {
            dao.Eliminar(id);
        }
    }
}