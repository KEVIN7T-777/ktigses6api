using ktigses6api.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net;

namespace ktigses6api.Views;

public partial class Crud : ContentPage
{
    private const string Url = "http://localhost:8082/api_rest_KEV/apikt.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Usuario> _usu;


    public Crud()
    {
        InitializeComponent();
        Mostrar();
    }

    public async void Mostrar()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Usuario> lista = JsonConvert.DeserializeObject<List<Usuario>>(content);

        _usu = new ObservableCollection<Usuario>(lista);
        lvUsu.ItemsSource = _usu;
    }

    private void btnNuevo_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new NewEstudent());
        }
        catch (Exception ex)
        {

            DisplayAlert("ALERTA", ex.Message, "CERRAR");
        }
    }

    private void lvUsu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            var objetoUsu = (Usuario)e.SelectedItem;
            Navigation.PushAsync(new UpdateEstudent(objetoUsu));
        }
        catch (Exception ex)
        {

            DisplayAlert("ALERTA", ex.Message, "CERRAR");
        }
    }
}