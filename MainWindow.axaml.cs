using Avalonia.Controls;
using Avalonia.Interactivity;
using SonicColeccion.Models;
using SonicColeccion.Services;
using System.Collections.Generic;
using System;

namespace SonicColeccion;

public partial class MainWindow : Window
{
    private readonly JuegoServicio servicio = new JuegoServicio();

    public MainWindow()
    {
        InitializeComponent();
        cmbEstado.ItemsSource = new[] { "Pendiente", "Jugando", "Completado" };
        CargarJuegos();
    }

    private void CargarJuegos()
    {
        lstJuegos.ItemsSource = servicio.Listar();
    }

    private void BtnGuardar_Click(object? sender, RoutedEventArgs e)
    {
        if (!int.TryParse(txtAnno.Text, out int anno))
        {
            lblMensaje.Text = "El año debe ser un número entero.";
            return;
        }
        if (!int.TryParse(txtCalificacion.Text, out int calificacion))
        {
            lblMensaje.Text = "La calificación debe ser un número entero.";
            return;
        }
        string estado = cmbEstado.SelectedItem as string ?? "";
        try
        {
            var juego = new Juego(
                txtTitulo.Text ?? "",
                anno,
                txtConsola.Text ?? "",
                estado,
                calificacion
                );
            servicio.Registrar(juego);
            CargarJuegos();
            lblMensaje.Text = "Juego guardado correctamente.";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    private void BtnActualizar_Click(object? sender, RoutedEventArgs e)
    {
        if (lstJuegos.SelectedItem is not Juego seleccionado)
        {
            lblMensaje.Text = "Selecciona un juego de la lista para actualizarlo.";
            return;
        }

        if (!int.TryParse(txtAnno.Text, out int anno))
        {
            lblMensaje.Text = "El año debe ser un número entero.";
            return;
        }
        if (!int.TryParse(txtCalificacion.Text, out int calificacion))
        {
            lblMensaje.Text = "La calificación debe ser un número entero.";
            return;
        }
        string estado = cmbEstado.SelectedItem as string ?? "";
        try
        {
            var juego = new Juego(
                seleccionado.Id,
                txtTitulo.Text ?? "",
                anno,
                txtConsola.Text ?? "",
                estado,
                calificacion
                );
            servicio.Modificar(juego);
            CargarJuegos();
            lblMensaje.Text = "Juego actualizado correctamente.";
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    private void LstJuegos_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (lstJuegos.SelectedItem is Juego juego)
        {
            txtTitulo.Text = juego.Titulo;
            txtAnno.Text = juego.Anno.ToString();
            txtConsola.Text = juego.Consola;
            txtCalificacion.Text = juego.Calificacion.ToString();
            cmbEstado.SelectedItem = juego.Estado;
        }
    }
}