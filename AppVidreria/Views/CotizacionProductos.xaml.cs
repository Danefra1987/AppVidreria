using AppVidreria.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AppVidreria.Views;

public partial class CotizacionProductos : ContentPage
{

    private List<Models.Producto> cotizacionProductosList { get; set; }

    public List<Models.Producto> CotizacionProductosList
    {
        get { return cotizacionProductosList; }
        set { this.cotizacionProductosList = value; }
    }
    public CotizacionProductos(List<Models.Producto> cotizacionProductosList)
    {
        InitializeComponent();
        this.cotizacionProductosList = cotizacionProductosList;
        lvCotizacionProductos.ItemsSource = this.cotizacionProductosList;
    }
}