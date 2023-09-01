using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVidreria.Models
{
    public class Producto : INotifyPropertyChanged
    {
        private int id;
        private string nombre;
        private string descripcion;
        private ImageSource imagen;
        private decimal alto;
        private decimal ancho;
        private decimal precio;
        private List<Material> materiales;
        public Producto()
        {

        }

        public List<Material> Materiales
        {
            get { return materiales; }
            set
            {
                materiales = value;
                OnPropertyChanged("Materiales");
            }
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

        public decimal Alto
        {
            get { return alto; }
            set
            {

                alto = value;
                OnPropertyChanged("Alto");
            }
        }

        public decimal Ancho
        {
            get { return ancho; }
            set
            {

                ancho = value;
                OnPropertyChanged("Ancho");
            }
        }

        public decimal Precio
        {
            get { return precio; }
            set
            {

                precio = value;
                OnPropertyChanged("Precio");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string nombre)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nombre));
            }
        }
    }
}
