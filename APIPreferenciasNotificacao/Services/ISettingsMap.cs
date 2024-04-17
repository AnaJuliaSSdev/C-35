using APIPreferenciasNotificacao.Options;

namespace APIPreferenciasNotificacao.Services;

public interface ISettingsMap
{
    NotificacaoOptions NotificacaoOptions { get; set; }
}
