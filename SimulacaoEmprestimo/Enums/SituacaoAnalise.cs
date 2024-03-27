using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SimulacaoEmprestimo.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SituacaoAnalise
{
    [Description("Aprovado")]
    Aprovado,
    [Description("Reprovado")]
    Reprovado,
}