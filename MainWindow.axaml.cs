using Avalonia.Controls;
using SonicColeccion.Models;
using SonicColeccion.Services;
using System.Collections.Generic;

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
}