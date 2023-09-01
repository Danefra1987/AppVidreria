using AppVidreria.DTOs;
using AppVidreria.Models;
using VistaCotizacionProductos = AppVidreria.Views.CotizacionProductos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVidreria.ViewModels
{
    public partial class ProductoViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<Producto> productoList;
        

        private ObservableCollection<Producto> cotizacionProductosList;


        #endregion
        #region Constructor
        public ProductoViewModel()
        {
            GenerateSource();
        }

        #endregion
        #region Properties
        public ObservableCollection<Producto> ProductoList
        {
            get { return productoList; }
            set { this.productoList = value; }
        }

        public ObservableCollection<Producto> CotizacionProductosList
        {
            get { return cotizacionProductosList; }
            set { this.cotizacionProductosList = value; }
        }

        #endregion
        #region Generate Source
        private void GenerateSource()
        {
            ProductoRepository productoinfo = new ProductoRepository();
            productoList = productoinfo.GetProductoInfo();
            cotizacionProductosList = new ObservableCollection<Producto>();
        }


        [RelayCommand]
        private void AgregarProductoEvent(Producto producto)
        {
            AgregarProductoACotizacion(producto);
            producto.Ancho = 0;
            producto.Alto = 0;
        }


        private void AgregarProductoACotizacion(Producto producto) 
        {
            Producto prod = new Producto() { 
                Id = 1,
                Nombre = producto.Nombre,
                Alto = producto.Alto,
                Ancho = producto.Ancho,
                Precio = 0,
                Materiales = producto.Materiales,

            };
            prod.Precio = CalcularPrecioProducto(producto);
            CotizacionProductosList.Add(prod);
        }

        private decimal CalcularPrecioProducto(Producto producto)
        {
            decimal precio = 0;

            foreach (Material material in producto.Materiales) 
            {
                if (material.UnidadMedida == "m")
                {
                    precio = precio + ((2 * producto.Ancho + 2 * producto.Alto) * material.PrecioUnidad);
                }
                else
                {
                    precio = precio + ((producto.Ancho * producto.Alto) * material.PrecioUnidad);
                }

            }
            return precio;
        }

        #endregion
    }
}
