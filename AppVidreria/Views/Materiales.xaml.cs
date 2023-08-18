using AppVidreria.Models;
using AppVidreria.ViewModels;

namespace AppVidreria.Views;

public partial class Materiales : ContentPage
{
	public Materiales()
	{
		InitializeComponent();
	}

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        //lvMateriales.ItemsSource = DataService.GetSearchResults(searchBar.Text);

        MaterialRepository categoryinfo = new MaterialRepository();
        lvMateriales.ItemsSource = categoryinfo.GetSearchResults(searchBar.Text);
        //if (lstMateriales.DataSource != null)
        //{
        //    this.lstMateriales.DataSource.Filter = FilterContacts;
        //    this.lstMateriales.DataSource.RefreshFilter();
        //}
    }

    private bool FilterContacts(object obj)
    {
        if (SearchBarMaterial == null || SearchBarMaterial.Text == null)
            return true;

        var materialesInfo = obj as Material;
        if (materialesInfo.Nombre.ToLower().Contains(SearchBarMaterial.Text.ToLower())
        || materialesInfo.Descripcion.ToLower().Contains(SearchBarMaterial.Text.ToLower()))
            return true;
        else
            return false;
    }
}