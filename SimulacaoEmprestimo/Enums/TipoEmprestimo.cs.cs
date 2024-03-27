using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SimulacaoEmprestimo.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoEmprestimo
{
    [Description("Pessoal")]
    Pessoal,
    [Description("Aposentado")]
    Aposentado,
}