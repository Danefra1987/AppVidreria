using System.ComponentModel;

namespace AppVidreria.Models
{
    public class Material: INotifyPropertyChanged
    {
        private int id;
        private string nombre;
        private string descripcion;
        private ImageSource imagen;
        
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
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
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
