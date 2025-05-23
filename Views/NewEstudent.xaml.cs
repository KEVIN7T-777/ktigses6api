using System.Net;

namespace ktigses6api.Views;

public partial class NewEstudent : ContentPage
{
    public NewEstudent()
    {
        InitializeComponent();
    }

    private void btnNuevo_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("email", txtCorreo.Text);
            cliente.UploadValues("http://localhost:8082/api_rest_KEV/apikt.php", "POST", parametros);
            Navigation.PushAsync(new Crud());
        }
        catch (Exception ex)
        {

            DisplayAlert("ALERTA", ex.Message, "CERRAR");
        }
    }
}