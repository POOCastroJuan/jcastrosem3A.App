namespace jcastrosem3A.Views;

public partial class vEstudiantes : ContentPage
{
    public vEstudiantes()
    {
        InitializeComponent();
    }
    private async void OnCalcularNotasClicked(object sender, EventArgs e)
    {
        try
        {
            string nombre = pickerEstudiantes.SelectedItem?.ToString() ?? "No seleccionado";

            double ns1 = ValidarNota(entryNS1.Text);
            double ex1 = ValidarNota(entryEX1.Text);
            double ns2 = ValidarNota(entryNS2.Text);
            double ex2 = ValidarNota(entryEX2.Text);

            double parcial1 = (ns1 * 0.3) + (ex1 * 0.2);
            double parcial2 = (ns2 * 0.3) + (ex2 * 0.2);
            double notaFinal = parcial1 + parcial2;

            string estado;
            if (notaFinal >= 7)
                estado = "APROBADO";
            else if (notaFinal >= 5)
                estado = "COMPLEMENTARIO";
            else
                estado = "REPROBADO";

            string fecha = datePicker.Date.ToString("dd/MM/yyyy");

            await DisplayAlert("Resultado",
                $"Nombre: {nombre}\n" +
                $"Fecha: {fecha}\n" +
                $"Nota Parcial 1: {parcial1:F2}\n" +
                $"Nota Parcial 2: {parcial2:F2}\n" +
                $"Nota Final: {notaFinal:F2}\n" +
                $"Estado: {estado}",
                "Aceptar");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ingrese valores válidos. {ex.Message}", "OK");
        }
    }

    private double ValidarNota(string valor)
    {
        if (double.TryParse(valor, out double nota))
        {
            if (nota >= 0 && nota <= 10)
                return nota;
            else
                throw new Exception("Las notas deben estar entre 0 y 10.");
        }
        else
        {
            throw new Exception("Entrada no válida.");
        }
    }
}