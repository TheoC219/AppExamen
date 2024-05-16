using System.Xml;

namespace AppExamen;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private void btnCalzado_Clicked(object sender, EventArgs e)
    {
        lblText.Text = "Calzado";

        Navigation.PushAsync(new CalzadoPage());
    }

    private void btnMarca_Clicked(object sender, EventArgs e)
    {
        lblText.Text = "Marca";

        Navigation.PushAsync(new MarcaPage());

    }
}