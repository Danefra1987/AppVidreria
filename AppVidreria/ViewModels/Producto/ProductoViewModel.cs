using AppVidreria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVidreria.ViewModels.Producto
{
    public class ProductoViewModel
    {
        #region Fields
        private ObservableCollection<ProductoModel> productoList;

        #endregion
        #region Constructor
        public ProductoViewModel()
        {
            GenerateSource();
        }

        #endregion
        #region Properties
        public ObservableCollection<ProductoModel> ProductoList
        {
            get { return productoList; }
            set { this.productoList = value; }
        }

        #endregion
        #region Generate Source
        private void GenerateSource()
        {
            ProductoRepository productoinfo = new ProductoRepository();
            productoList = productoinfo.GetProductoInfo();
        }

        #endregion
    }
}
