using ktigses6api.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ktigses6api.Views;

public partial class Mascota : ContentPage
{
    private const string Url = "http://localhost:8082/api_rest_KEV/apiMascota.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Mascota> _mas;

    public Mascota()
	{
		InitializeComponent();
        Mostrar();
	}

    public async void Mostrar()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Mascota> lista = JsonConvert.DeserializeObject<List<Mascota>>(content);

        _mas = new ObservableCollection<Mascota>(lista);
        lvMas.ItemsSource = _mas;
    }
}