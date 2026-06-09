using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ConversorAppQ22026.ViewModels;

public partial class LongitudViewModel : ObservableObject
{
    [ObservableProperty]
    private string valor = string.Empty;

    [ObservableProperty]
    private string resultado = string.Empty;

    [ObservableProperty]
    private string tipoConversion = "Metros -> Kilómetros";

    public List<string> TiposConversion { get; } = new()
    {
        "Metros -> Kilómetros",
        "Kilómetros -> Metros",
        "Metros -> Pies",
        "Pies -> Metros",
        "Pulgadas -> Centímetros",
        "Centímetros -> Pulgadas"
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
            "Metros -> Kilómetros" => numero / 1000,
            "Kilómetros -> Metros" => numero * 1000,
            "Metros -> Pies" => numero * 3.28084,
            "Pies -> Metros" => numero / 3.28084,
            "Pulgadas -> Centímetros" => numero * 2.54,
            "Centímetros -> Pulgadas" => numero / 2.54,
            _ => 0
        };

        Resultado = $"{numero:F2} -> {res:F4}";
    }

    [RelayCommand]
    private void Limpiar()
    {
        Valor = string.Empty;
        Resultado = string.Empty;
    }
}