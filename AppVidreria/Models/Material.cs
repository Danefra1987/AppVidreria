using System.ComponentModel;

namespace AppVidreria.Models
{
    public class Material : INotifyPropertyChanged
    {
        private int id;
        private int cantidad;
        private string nombre;
        private string descripcion;
        private ImageSource imagen;
        private decimal precioUnidad;
        private string unidadMedida;

        /// <summary>
        /// Constructor
        /// </summary>
        public Material()
        {

        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("nombre");
            }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string UnidadMedida
        {
            get { return unidadMedida; }
            set
            {
                unidadMedida = value;
                OnPropertyChanged("UnidadMedida");
            }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }

        public ImageSource Imagen
        {
            get { return imagen; }
            set
            {
                imagen = value;
                OnPropertyChanged("Image");
            }
        }

        public decimal PrecioUnidad
        {
            get { return precioUnidad; }
            set {

                precioUnidad = value;
                OnPropertyChanged("PrecioUnidad");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string nombre)
        {
            if (this.PropertyChanged !=null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nombre));
            }
        }
    }
}
