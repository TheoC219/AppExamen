using AppExamen.Models;
namespace AppExamen;

public partial class MarcaPage : ContentPage
{
    private string urlApiMarca = "https://apptheoserver.azurewebsites.net/api/Marcas";
    public MarcaPage()
	{
		InitializeComponent();
	}
    private void btnCreateMarca_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Marca>.Create(urlApiMarca, new Marca
            {
                Id = 0,
                Descripcion = txtMarca.Text
            });

            if (resultado != null)
            {
                txtId.Text = resultado.Id.ToString();
                DisplayAlert("Mensaje", "Registro creado:" + txtId.Text + " - " + txtMarca.Text, "OK");
            }
            else
            {
                DisplayAlert("Mensaje", "Error al crear", "OK");
            }
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al crear", "OK");
        }

    }

    private void btnReadMarca_Clicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = ApiConsumer.Crud<Marca>.Read_ById(urlApiMarca, int.Parse(txtId.Text));
            if (resultado != null)

                txtMarca.Text = resultado.Descripcion;

            else

                DisplayAlert("Mensaje", "Registro no encontrado", "OK");

        }
        catch
        {
            DisplayAlert("Mensaje", "Error al buscar", "OK");
        }
    }

    private void btnUpdateMarca_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Marca>.Update(urlApiMarca, int.Parse(txtId.Text), new Marca
            {
                Id = int.Parse(txtId.Text),
                Descripcion = txtMarca.Text
            });
            DisplayAlert("Mensaje", "Registro actualizado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al actualizar", "OK");
        }

    }


    private void btnDeleteMarca_Clicked(object sender, EventArgs e)
    {
        try
        {
            ApiConsumer.Crud<Marca>.Delete(urlApiMarca, int.Parse(txtId.Text));
            txtMarca.Text = "";
            txtId.Text = "";
            DisplayAlert("Mensaje", "Registro eliminado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al eliminar", "OK");
        }

    }
}