using AppExamen.Models;
namespace AppExamen;

public partial class CalzadoPage : ContentPage
{
    private string urlApiCalzado = "https://apptheoserver.azurewebsites.net/api/Calzados";
    public CalzadoPage()
	{
		InitializeComponent();
	}
    private async void btnCreateCalzado_Clicked(object sender, EventArgs e)
    {
        try
        {
            var nuevoCalzado = new Calzado
            {
                Id = 0,
                Tipo = txtTipoCalzado.Text,
                PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
                Talla = int.Parse(txtTalla.Text),
                IVA = int.Parse(txtIVA.Text),
                MarcaId = int.Parse(txtMarcaId.Text)
            };

            var resultado = ApiConsumer.Crud<Calzado>.Create(urlApiCalzado, nuevoCalzado);

            if (resultado != null)
            {
                txtIdCalzado.Text = resultado.Id.ToString();
                await DisplayAlert("Mensaje", $"Registro creado: {resultado.Id}", "OK");
            }
            else
            {
                await DisplayAlert("Mensaje", "Error al crear", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Mensaje", $"Error al crear: {ex.Message}", "OK");
        }
    }

    private async void btnReadCalzado_Clicked(object sender, EventArgs e)
    {
        try
        {
            int idCalzado = int.Parse(txtIdCalzado.Text);
            var resultado = ApiConsumer.Crud<Calzado>.Read_ById(urlApiCalzado, idCalzado);

            if (resultado != null)
            {
                txtTipoCalzado.Text = resultado.Tipo;
                txtPrecioUnitario.Text = resultado.PrecioUnitario.ToString();
                txtTalla.Text = resultado.Talla.ToString();
                txtIVA.Text = resultado.IVA.ToString();
                txtMarcaId.Text = resultado.MarcaId.ToString();
            }
            else
            {
                await DisplayAlert("Mensaje", "Registro no encontrado", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Mensaje", $"Error al buscar: {ex.Message}", "OK");
        }
    }

    private async void btnUpdateCalzado_Clicked(object sender, EventArgs e)
    {
        try
        {
            var calzadoActualizado = new Calzado
            {
                Id = int.Parse(txtIdCalzado.Text),
                Tipo = txtTipoCalzado.Text,
                PrecioUnitario = double.Parse(txtPrecioUnitario.Text),
                Talla = int.Parse(txtTalla.Text),
                IVA = int.Parse(txtIVA.Text),
                MarcaId = int.Parse(txtMarcaId.Text)
            };

            ApiConsumer.Crud<Calzado>.Update(urlApiCalzado, calzadoActualizado.Id, calzadoActualizado);

            DisplayAlert("Mensaje", "Registro actualizado", "OK");
        }
        catch
        {
            DisplayAlert("Mensaje", "Error al actualizar", "OK");
        }
    }

    private async void btnDeleteCalzado_Clicked(object sender, EventArgs e)
    {
        try
        {
            int idCalzado = int.Parse(txtIdCalzado.Text);
            ApiConsumer.Crud<Calzado>.Delete(urlApiCalzado, idCalzado);

            
                txtIdCalzado.Text = "";
                txtTipoCalzado.Text = "";
                txtPrecioUnitario.Text = "";
                txtTalla.Text = "";
                txtIVA.Text = "";
                txtMarcaId.Text = "";

                await DisplayAlert("Mensaje", "Registro eliminado", "OK");
            
        }
        catch (Exception ex)
        {
            await DisplayAlert("Mensaje", $"Error al eliminar: {ex.Message}", "OK");
        }
    }

}