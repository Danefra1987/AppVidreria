using AppVidreria.Models;
using AppVidreria.ViewModels;
using MigraDocCore.Rendering;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace AppVidreria.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Materiales : ContentPage
{
	public Materiales()
	{
		InitializeComponent();
	}

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;

        MaterialRepository categoryinfo = new MaterialRepository();
        lvMateriales.ItemsSource = categoryinfo.GetSearchResults(searchBar.Text);
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

    private void GeneratePDF(object sender, EventArgs e)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        PdfSharpCore.Pdf.PdfDocument document = new PdfSharpCore.Pdf.PdfDocument();

        PdfSharpCore.Pdf.PdfPage page = document.AddPage();

        PdfSharpCore.Drawing.XGraphics gfx = XGraphics.FromPdfPage(page);
        gfx.MUH = PdfFontEncoding.Unicode;

        var ren = new PdfDocumentRenderer(true);

        XFont font = new XFont("OpenSans-Semibold", 20, XFontStyle.Bold);

        gfx.DrawString("Hello, World!", font, XBrushes.Black, 10, 10);



        var path = DeviceInfo.Platform == DevicePlatform.Android ? "/storage/emulated/0/Download" : Path.GetTempPath();
        SaveDoc(document, "Cotizacion1.pdf", path);


        Application.Current.MainPage.DisplayAlert(
            "Success",
            $"Your PDF generated at {path}",
            "OK");
    }

    public static void SaveDoc(PdfDocument document, string fileName, string path = default)
    {
        var location = Path.Join(path, fileName);

        document.Save(location);
        document.Close();
    }
}