using ktigses6api.Models;
using System.Text;

namespace ktigses6api.Views;

public partial class UpdateEstudent : ContentPage
{
    public UpdateEstudent(Usuario datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.Id.ToString();
        txtNombre.Text = datos.Nombre.ToString();
        txtCorreo.Text = datos.Email.ToString();
    }

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            var datosJson = new Dictionary<string, string>
        {
            { "nombre", txtNombre.Text },
            { "email", txtCorreo.Text }
        };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(datosJson);
            var contenido = new StringContent(json, Encoding.UTF8, "application/json");

            using var cliente = new HttpClient();

            string url = $"http://localhost:8082/api_rest_KEV/apikt.php?id={txtCodigo.Text}";

            HttpResponseMessage respuesta = await cliente.PutAsync(url, contenido);

            string respuestaContenido = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Usuario actualizado correctamente", "OK");
                await Navigation.PushAsync(new Crud());
            }
            else
            {
                await DisplayAlert("Error", $"Error HTTP {respuesta.StatusCode}\n{respuestaContenido}", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }



    private async void btnBorrar_Clicked(object sender, EventArgs e)
    {
        bool confirmacion = await DisplayAlert("Confirmar", "¿Deseas eliminar este usuario?", "Sí", "No");
        if (!confirmacion) return;

        try
        {
            using var cliente = new HttpClient();
            string url = $"http://localhost:8082/api_rest_KEV/apikt.php?id={txtCodigo.Text}";
            HttpResponseMessage respuesta = await cliente.DeleteAsync(url);
            respuesta.EnsureSuccessStatusCode();

            await DisplayAlert("Eliminado", "Usuario eliminado correctamente", "OK");
            Navigation.PushAsync(new Crud());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "Cerrar");
        }
    }

}