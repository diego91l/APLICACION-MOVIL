namespace DANAMISETS3.Vistas;

public partial class vLogin : ContentPage
{
    // Datos de conexión
    string[] users = { "Carlos", "Ana", "Jose" };
    string[] passwords = { "carlos123", "ana123", "jose123" };
    public vLogin()
	{
		InitializeComponent();
	}

    private void btbInicio_Clicked(object sender, EventArgs e)
    {
        string username = txtUsuario.Text;
        string password = txtContrasena.Text;

        // Verificar credenciales
        bool isAuthenticated = CheckCredentials(username, password);

        if (isAuthenticated)
        {
            DisplayAlert("Alerta", "Inicio de sesión exitoso", "Cerrado");
            Navigation.PushAsync(new vPagina(username));
        }
        else
        {
            DisplayAlert("Alerta", "Usuario/contrasena incorrectos", "Cerrado");
            txtUsuario.Text = "";
            txtContrasena.Text = "";
        }

    }

    private bool CheckCredentials(string username, string password)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == username && passwords[i] == password)
                return true;
        }
        return false;
    }

    private void btnRegistro_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vRegistro());
    }
}