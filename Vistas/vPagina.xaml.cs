namespace DANAMISETS3.Vistas;

public partial class vPagina : ContentPage
{
    double promedioSemestre = 0;
    double promedio1 = 0;
    double promedio2 = 0;
    public vPagina(string usuario)
	{
		InitializeComponent();
        DisplayAlert("Bienvenido", usuario, "Cerrar");
        lblUsuario.Text = "Usuario conectado: " + usuario;
    }

    private void btnSeguimiento1_Clicked(object sender, EventArgs e)
    {
        int seguimiento1 = Convert.ToInt32(txtSeguimiento1.Text);
        int examen1 = Convert.ToInt32(txtExamen1.Text);
        promedio1 = (seguimiento1 * 0.3) + (examen1 * 0.2);

        if (seguimiento1 >= 0.01 && examen1 <= 10)
        {
            lblPromedio1.Text = "Promedio Parcial 1: " + promedio1.ToString();
            DisplayAlert("Alerta", "Promedio Parcial 1: " + promedio1.ToString(), "cerrar");
        }
        else
        {
            DisplayAlert("Alerta", "Las notas deben ser entre 0 y 10", "cerrar");
            txtSeguimiento1.Text = "";
            txtExamen1.Text = "";
            lblPromedio1.Text = "";
        }


        promedioSemestre = promedio1 + promedio2;


    }

    private void btnSeguimiento2_Clicked(object sender, EventArgs e)
    {
        int seguimiento2 = Convert.ToInt32(txtSeguimiento2.Text);
        int examen2 = Convert.ToInt32(txtExamen2.Text);
        promedio2 = ((seguimiento2 * 0.3) + (examen2 * 0.2));

        if (seguimiento2 >= 0.01 && examen2 <= 10)
        {
            lblPromedio2.Text = "Promedio Parcial 2: " + promedio2.ToString();
            DisplayAlert("Alerta", "nota  Parcial 2 : " + promedio2, "cerrar");
        }
        else
        {
            DisplayAlert("Alerta", "Las notas deben ser entre 0 y 10", "cerrar");
            txtSeguimiento2.Text = "";
            txtExamen2.Text = "";
            lblPromedio2.Text = "";
        }


        promedioSemestre = promedio1 + promedio2;
        lblPromedioSemestre.Text = "Promedio Semestre: " + promedioSemestre.ToString();
        MostrarEstado(promedioSemestre);

    }

    private string MostrarEstado(double notaFinal)
    {
        string estado = "";
        if (notaFinal >= 7)
        {
            estado = "Aprobado";
        }
        else if (notaFinal >= 5 && notaFinal <= 6.9)
        {
            estado = "Complementario";
        }
        else
        {
            estado = "Reprobado";
        }
        lblEstadoSemestre.Text = "Estado: " + estado;
        return estado;
    }

   
    private void btnInforme_Clicked_1(object sender, EventArgs e)
    {
        DateTime selectedDate = datePicker.Date;

        var selectedName = pkseleccion.Items[pkseleccion.SelectedIndex];
        var estado = MostrarEstado(promedioSemestre);

        DisplayAlert("Informe:",
                     "Estudiante: " + selectedName + "\nFecha: " + selectedDate.ToString("dd/MM/yyyy") + "\nParcial 1: " + promedio1 + "\nParcial 2: " + promedio2 + "\nPromedio Final: " + promedioSemestre + "\nEstado: " + estado,
                     "Cerrar");
    }

    private void btnNuevo_Clicked(object sender, EventArgs e)
    {
        txtSeguimiento1.Text = "";
        txtExamen1.Text = "";
        lblPromedio1.Text = "";
        txtSeguimiento2.Text = "";
        txtExamen2.Text = "";
        lblPromedio2.Text = "";
        lblPromedioSemestre.Text = "";
        lblEstadoSemestre.Text = "";
        promedio1 = 0;
        promedio2 = 0;
        promedioSemestre = 0;
        pkseleccion.SelectedIndex = -1;

    }
}