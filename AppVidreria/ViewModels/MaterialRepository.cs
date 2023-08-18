using AppVidreria.Models;
using System.Collections.ObjectModel;

namespace AppVidreria.ViewModels
{
    public class MaterialRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialRepository()
        {

        }

        internal ObservableCollection<Material> GetCategoryInfo()
        {
            var materialInfo = new ObservableCollection<Material>();
            for (int i = 0; i < Names.Count(); i++)
            {
                var info = new Material()
                {
                    Id = i,
                    Nombre = Names[i],
                    Descripcion = Descriptions[i],
                    Imagen = Images[i],
                    Precio= Precio[i]
                };
                materialInfo.Add(info);
            }
            return materialInfo;
        }

        internal ObservableCollection<Material> GetSearchResults(string strTexto)
        {
            var materialInfo = new ObservableCollection<Material>();

            for (int i = 0; i < Names.Count(); i++)
            {
                if (Names[i].Contains(strTexto))
                {
                    var info = new Material()
                    {
                        Id = i,
                        Nombre = Names[i],
                        Descripcion = Descriptions[i],
                        Imagen = Images[i],
                        Precio = Precio[i]
                    };
                    materialInfo.Add(info);
                }
            }
            return materialInfo;
        }

        string[] Names = new string[]
          {
            "Transparente 3mm",
            "Transparente 4mm",
            "Transparente 6mm",
            "Espejo de 3mm",
            "Espejo de 4mm",
            "Espejo de 6mm",
          };

        string[] Images = new string[]
          {
             "cotizar.png",
             "vidrieria.png",
             "home.png",
             "producto.png",
             "cotizar_lapiz.png",
             "vidrieria.png"
          };

        string[] Descriptions = new string[]
        {
            "Vidrio transparente de 3mm",
            "Vidrio transparente de 4mm",
            "Vidrio transparente de 6mm",
            "Espejo de 3mm de grosor",
            "Espejo de 4mm de grosor",
            "Espejo de 6mm de grosor"
        };
        string[] Precio = new string[]
        {
            "12.56",
            "15.02",
            "10,90",
            "8,90",
            "4,50",
            "9.80"
        };
    }

    public class MaterialViewModel
    {
        #region Fields
        private ObservableCollection<Material> categoryList;

        #endregion
        #region Constructor
        public MaterialViewModel()
        {
            GenerateSource();
        }

        #endregion
        #region Properties
        public ObservableCollection<Material> CategoryList
        {
            get { return categoryList; }
            set { this.categoryList = value; }
        }

        #endregion
        #region Generate Source
        private void GenerateSource()
        {
            MaterialRepository categoryinfo = new MaterialRepository();
            categoryList = categoryinfo.GetCategoryInfo();
        }

        #endregion
    }

}
