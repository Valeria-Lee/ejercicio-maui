using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace EjercicioMaui {
    public partial class MainPage : ContentPage {
        public MainPage() {
            BindingContext = this;
            InitializeComponent();
            GetData();
        }

        private readonly HttpClient _httpClient = new HttpClient();
        private ObservableCollection<PersonaModel> _personas;

        public ObservableCollection<PersonaModel> Personas {
            get => _personas;
            set {
                _personas = value;
                OnPropertyChanged();
            }
        }

        public async void GetData() {
            var res = await _httpClient.GetStringAsync("https://fi.jcaguilar.dev/v1/escuela/persona");
            var personas = JsonSerializer.Deserialize<ObservableCollection<PersonaModel>>(res);
            
            Personas = personas;

            Debug.WriteLine(personas);
        }

        private async void btnForm_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new FormPage());
        }
    }

}
