using AppVidreria.Utilities;
using PdfSharpCore.Fonts;

namespace AppVidreria;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        GlobalFontSettings.FontResolver = new FileFontResolver();
        MainPage = new AppShell();
	}
}
