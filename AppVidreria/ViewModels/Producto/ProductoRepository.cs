using AppVidreria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVidreria.ViewModels.Producto
{
    public class ProductoRepository
    {
        public ProductoRepository()
        {

        }
        internal ObservableCollection<ProductoModel> GetProductoInfo()
        {
            var productoInfo = new ObservableCollection<ProductoModel>();
            for (int i = 0; i < Names.Count(); i++)
            {
                var info = new ProductoModel()
                {
                    Id = i,
                    Nombre = Names[i],
                    Descripcion = Descriptions[i],
                    Imagen = Images[i],
                    Precio = Precio[i]
                };
                productoInfo.Add(info);
            }
            return productoInfo;
        }

        internal ObservableCollection<ProductoModel> GetProductoSearchResults(string strTexto)
        {
            var productoInfo = new ObservableCollection<ProductoModel>();

            for (int i = 0; i < Names.Count(); i++)
            {
                if (Names[i].Contains(strTexto))
                {
                    var info = new ProductoModel()
                    {
                        Id = i,
                        Nombre = Names[i],
                        Descripcion = Descriptions[i],
                        Imagen = Images[i],
                        Precio = Precio[i]
                    };
                    productoInfo.Add(info);
                }
            }
            return productoInfo;
        }

        string[] Names = new string[]
          {
            "Ventana",
            "Puerta"
          };

        string[] Images = new string[]
          {
             "cotizar.png",
             "vidrieria.png"
          };

        string[] Descriptions = new string[]
        {
            "Espejo de 4mm de grosor",
            "Espejo de 6mm de grosor"
        };
        decimal[] Precio = new decimal[]
        {
            200.50m,
            300.80m
        };

    }

   
}
