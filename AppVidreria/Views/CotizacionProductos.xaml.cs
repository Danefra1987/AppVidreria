using AppVidreria.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AppVidreria.Views;

public partial class CotizacionProductos : ContentPage
{
    public List<Producto> Productos;
    private ObservableCollection<Models.Producto> cotizacionProductosList;

    public CotizacionProductos(List<Producto> _productos)
	{
        Productos = _productos;
        InitializeComponent();
	}

    public CotizacionProductos(ObservableCollection<Models.Producto> cotizacionProductosList)
    {
        this.cotizacionProductosList = cotizacionProductosList;
    }
}