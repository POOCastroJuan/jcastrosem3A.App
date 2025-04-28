namespace jcastrosem3A.Views;

public partial class vLogin : ContentPage
{
  
    private string[] usuarios = { "Carlos", "Ana", "Jose" };
    private string[] contrasenas = { "carlos123", "ana123", "jose123" };

    public vLogin()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string usuarioIngresado = entryUser.Text?.Trim();
        string contrasenaIngresada = entryPass.Text;

        bool loginExitoso = false;
        string nombreUsuario = "";

        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuarios[i].Equals(usuarioIngresado, StringComparison.OrdinalIgnoreCase) &&
                contrasenas[i] == contrasenaIngresada)
            {
                loginExitoso = true;
                nombreUsuario = usuarios[i];
                break;
            }
        }

        if (loginExitoso)
        {
            await DisplayAlert("Bienvenido", $"¡Hola {nombreUsuario}!", "Aceptar");

          
            await Navigation.PushAsync(new vEstudiantes());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "Aceptar");
        }
    }
}