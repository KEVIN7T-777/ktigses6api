using ktigses6api.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

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
}