using AppVidreria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVidreria.ViewModels
{
    public class ProductoRepository
    {
        public ProductoRepository()
        {

        }
        internal ObservableCollection<Producto> GetProductoInfo()
        {
            var productoInfo = new ObservableCollection<Producto>();
            for (int i = 0; i < Names.Count(); i++)
            {
                var info = new Producto()
                {
                    Id = i,
                    Nombre = Names[i],
                    Descripcion = Descriptions[i],
                    Imagen = Images[i],
                    Precio = Precio[i],
                    Materiales = GetListaMateriales()
                };
                productoInfo.Add(info);
            }
            return productoInfo;
        }

        internal ObservableCollection<Producto> GetProductoSearchResults(string strTexto)
        {
            var productoInfo = new ObservableCollection<Producto>();

            for (int i = 0; i < Names.Count(); i++)
            {
                if (Names[i].Contains(strTexto))
                {
                    var info = new Producto()
                    {
                        Id = i,
                        Nombre = Names[i],
                        Descripcion = Descriptions[i],
                        Imagen = Images[i],
                        Precio = Precio[i],
                        Materiales = GetListaMateriales()
                    };
                    productoInfo.Add(info);
                }
            }
            return productoInfo;
        }
        internal List<Material> GetListaMateriales()
        {
            List<Material> listaMateriales = new List<Material>();
            listaMateriales.Add(new Material()
            {
                Id = 1,
                Nombre = "Vara de metal",
                UnidadMedida = "m",
                PrecioUnidad = decimal.Parse("2.5"),

            });
            listaMateriales.Add(new Material()
            {
                Id = 1,
                Nombre = "Vidrio",
                UnidadMedida = "m2",
                PrecioUnidad = decimal.Parse("15.7"),

            });
            return listaMateriales;
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
