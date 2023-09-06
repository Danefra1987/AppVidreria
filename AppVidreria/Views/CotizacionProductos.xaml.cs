using AppVidreria.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AppVidreria.Views;

public partial class CotizacionProductos : ContentPage
{

    private List<Models.Producto> cotizacionProductosList { get; set; }

    public List<Models.Producto> CotizacionProductosList
    {
        get { return cotizacionProductosList; }
        set { this.cotizacionProductosList = value; }
    }
    public CotizacionProductos(List<Models.Producto> cotizacionProductosList)
    {
        InitializeComponent();
        this.cotizacionProductosList = cotizacionProductosList;
        lvCotizacionProductos.ItemsSource = this.cotizacionProductosList;

        decimal total = 0m;

        foreach (var item in cotizacionProductosList)
        {
            total = total + item.Precio;
        }
        txtValorTotal.Text = total.ToString();
    }

    private async void BtnCompartir_Clicked(object sender, EventArgs e)
    {
        var file =await  CompartirPantalla(Capture);
        await ShareFile(file);
    }

    public async Task<string> CompartirPantalla(View contenedor)
    {
        if (Screenshot.Default.IsCaptureSupported)
        {
            var screen = await contenedor.CaptureAsync();
            Stream stream = await screen.OpenReadAsync(ScreenshotFormat.Png, 100);
            string fileDestino = Path.Combine(FileSystem.Current.AppDataDirectory, "capture.png");
            using (var fileStream = File.Create(fileDestino))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
            return fileDestino;
        }
        return "";

    }

    public async Task ShareFile(string file)
    {
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Cotizacion",
            File = new ShareFile(file)
        });
    }
}