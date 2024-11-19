using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace EjercicioMaui;

public partial class FormPage : ContentPage
{
    public bool nombreEscrito = false;
    public bool apellidoEscrito = false;

    private readonly HttpClient _httpClient = new HttpClient();

    public FormPage()
	{
		InitializeComponent();
	}

    private void txtApellido_Completed(object sender, EventArgs e) {
        nombreEscrito = true;
    }

    private void txtNombre_Completed(object sender, EventArgs e) {
        apellidoEscrito = true;
    }

    private void btnCrear_Clicked(object sender, EventArgs e)
    {
        if (nombreEscrito && apellidoEscrito)
        {
            Debug.WriteLine("boton presionado");
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;

            var persona = new PersonaModel
            {
                nombre = nombre,
                apellido = apellido
            };

            var personaJson = JsonSerializer.Serialize(persona);

            Debug.WriteLine(personaJson);

            var reqContent = new StringContent(personaJson, Encoding.UTF8, "application/json");

            try {
                makeReq(reqContent).ConfigureAwait(false);
            }
            catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private async Task makeReq(StringContent req) {
        var res = await _httpClient.PostAsync("https://fi.jcaguilar.dev/v1/escuela/persona", req);
        await Navigation.PopAsync();
        Debug.WriteLine("Persona Enviada");
    }

}