using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ConversorAppQ22026.ViewModels;

public partial class TemperaturaViewModel : ObservableObject
{
    [ObservableProperty]
    private string valor = string.Empty;

    [ObservableProperty]
    private string resultado = string.Empty;

    [ObservableProperty]
    private string tipoConversion = "Celsius -> Fahrenheit";

    public List<string> TiposConversion { get; } = new()
    {
        "Celsius -> Fahrenheit",
        "Fahrenheit -> Celsius",
        "Celsius -> Kelvin",
        "Kelvin -> Celsius"
    };

    [RelayCommand]
    private void Convertir()
    {
        if (!double.TryParse(Valor, out double numero))
        {
            Resultado = "Ingrese un número válido";
            return;
        }

        double res = TipoConversion switch
        {
            "Celsius -> Fahrenheit" => (numero * 9/5) + 32,
            "Fahrenheit -> Celsius" => (numero - 32) * 5/9,
            "Celsius -> Kelvin" => numero + 273.15,
            "Kelvin -> Celsius" => numero - 273.15,
            _ => 0
        };

        Resultado = $"{numero:F2} -> {res:F2}";
    }

    [RelayCommand]
    private void Limpiar()
    {
        Valor = string.Empty;
        Resultado = string.Empty;
    }
}