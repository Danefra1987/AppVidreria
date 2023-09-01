using AppVidreria.DTOs;
using AppVidreria.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.Rendering;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Collections.ObjectModel;
using Style = MigraDocCore.DocumentObjectModel.Style;
using Colors = MigraDocCore.DocumentObjectModel.Colors;
using AppVidreria.Utilities;

namespace AppVidreria.ViewModels
{
    public partial class MaterialViewModel : ObservableObject
    {
        #region Fields
        [ObservableProperty]
        private ObservableCollection<Material> materialesList;

        [ObservableProperty]
        public decimal total = 0;

        private CotizacionDTO cotizacion;

        #endregion
        #region Constructor
        public MaterialViewModel()
        {
            GenerateSource();
        }

        #endregion
        #region Properties
        #endregion
        #region Generate Source
        private void GenerateSource()
        {
            MaterialRepository materialInfo = new MaterialRepository();
            MaterialesList = materialInfo.GetMaterialInfo();
            InstanciarObjetoCotizacion();
        }

        [RelayCommand]
        private void DisminuirEvent(Material material)
        {
            material.Cantidad--;
            ActualizaDato(material);
        }


        [RelayCommand]
        private void AumentarEvent(Material material)
        {
            material.Cantidad++;
            ActualizaDato(material);
        }

        [RelayCommand]
        private void GenerarPDFEvent()
        {
            GeneratePDF();
        }

        #endregion

        #region utilidades
        public void InstanciarObjetoCotizacion()
        {
            cotizacion = new CotizacionDTO()
            {total = 0};

            List<MaterialDTO> materiales = new List<MaterialDTO>();
            
            for (int i = 0; i < MaterialesList.Count; i++)
            {
                materiales.Add(new MaterialDTO
                {
                    id = MaterialesList.ElementAt(i).Id,
                    nombre = MaterialesList.ElementAt(i).Nombre,
                    descripcion = MaterialesList.ElementAt(i).Descripcion,
                    precio = MaterialesList.ElementAt(i).PrecioUnidad,
                    cantidad = 0,
                });
            } 
            cotizacion.materiales = materiales;
        }

        public void ActualizaDato(Material material)
        {
            var index = cotizacion.materiales.FindIndex(c => c.id == material.Id);
            cotizacion.materiales[index].cantidad = material.Cantidad;
            cotizacion.total = CalcularTotal();
            Total = cotizacion.total;
        }

        public decimal CalcularTotal()
        {
            decimal calculo = 0;
            foreach (MaterialDTO item in cotizacion.materiales)
            {
                if (item.cantidad > 0 )
                {
                    calculo = calculo + (item.cantidad * item.precio);
                }
            }
            return calculo;
        }


        private void GeneratePDF()
        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Document document = CreateTable();
            var path = DeviceInfo.Platform == DevicePlatform.Android ? "/storage/emulated/0/Download" : Path.GetTempPath();
            SaveDocument(document, "Cotizacion.pdf", path);
            
            Application.Current.MainPage.DisplayAlert(
                "Success",
                $"Su PDF se a creado en la ruta {path}",
                "OK");
        }


        public static void SaveDocument(Document document, string fileName, string path = default)
        {
            var location = Path.Combine(FileSystem.CacheDirectory, fileName);
            var renderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };

            renderer.PrepareRenderPages();
            renderer.RenderDocument();

            renderer.Save(location);
            EnviarCorreo objCorrero = new EnviarCorreo();
            string[] correo = new[] { "daneframetal@hotmail.com", "esneider_98@outlook.com" };
            objCorrero.EnviarCorreoCotizacion(string.Empty, string.Empty, correo);
        }

        private Document CreateTable()
        {
            Document document = CreateDocument();
            Section sectionProtocolHeader = document.AddSection();
            Paragraph measValueParagraph = sectionProtocolHeader.AddParagraph("Cotización Materiales.");
            measValueParagraph = sectionProtocolHeader.AddParagraph("");
            measValueParagraph = sectionProtocolHeader.AddParagraph("");

            MigraDocCore.DocumentObjectModel.Tables.Table table = sectionProtocolHeader.AddTable();
            table.Borders.Width = 0.3;
            table.Format.LeftIndent = 0.8;

            // Table header      
            Column column = table.AddColumn("5,8cm");
            column = table.AddColumn("1,9cm");
            column = table.AddColumn("3,8cm");
            column = table.AddColumn("4,9cm");

            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Left;
            row.Format.Font.Bold = true;

            row.Cells[0].AddParagraph("Material");
            row.Cells[1].AddParagraph("Cantidad");
            row.Cells[2].AddParagraph("Precio Unitario");
            row.Cells[3].AddParagraph("Precio Total Producto");

            decimal totalCotizacion = 0;
            // Table data
            for (int i = 0; i < cotizacion.materiales.Count; i++)
            {
                if (cotizacion.materiales[i].cantidad > 0)
                {
                    row = table.AddRow();
                    row.Cells[0].AddParagraph(cotizacion.materiales[i].nombre);
                    row.Cells[1].AddParagraph(cotizacion.materiales[i].cantidad.ToString());
                    row.Cells[2].AddParagraph("$ "+ cotizacion.materiales[i].precio.ToString());
                    row.Cells[3].AddParagraph("$ " + (decimal.Parse(cotizacion.materiales[i].cantidad.ToString()) * cotizacion.materiales[i].precio).ToString());

                    totalCotizacion = totalCotizacion + (decimal.Parse(cotizacion.materiales[i].cantidad.ToString()) * cotizacion.materiales[i].precio);

                }
            }
            measValueParagraph = sectionProtocolHeader.AddParagraph("");
            measValueParagraph = sectionProtocolHeader.AddParagraph("Total Cotización: $" + totalCotizacion.ToString());
            return document;
        }
        public static Document CreateDocument()
        {
            // Create a new MigraDocCore document
            Document document = new Document();
            document.Info.Title = "Documento de cotización.";
            document.Info.Subject = "Documento de cotización.";
            document.Info.Author = "Esneider Santander";
            DefineStyles(document);
            return document;
        }


        public static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "OpenSans-Semibold";
    
            style = document.Styles["Heading1"];
            style.Font.Name = "OpenSans-Semibold";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;
    
            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;
    
            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;
    
            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);
    
            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);
    
            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;
    
            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }

        #endregion

    }
}
