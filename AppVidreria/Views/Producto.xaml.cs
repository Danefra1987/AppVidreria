using AppVidreria.ViewModels.Producto;

namespace AppVidreria.Views;

public partial class Producto : ContentPage
{
	public Producto()
	{
		InitializeComponent();
	}

    private void SearchBarProducto_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;

        ProductoRepository categoryinfo = new ProductoRepository();
        lvProducto.ItemsSource = categoryinfo.GetProductoSearchResults(searchBar.Text);
    }
}