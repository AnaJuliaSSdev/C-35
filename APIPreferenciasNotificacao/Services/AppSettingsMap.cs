using APIPreferenciasNotificacao.Options;
using Microsoft.Extensions.Options;

namespace APIPreferenciasNotificacao.Services;

public class AppSettingsMap : ISettingsMap
{
    public AppSettingsMap(IOptionsMonitor<NotificacaoOptions> notificacaoOptions)
    {
        NotificacaoOptions = notificacaoOptions.CurrentValue;
        notificacaoOptions.OnChange(config =>
        {
            NotificacaoOptions = config;
        });
    }
        
    public NotificacaoOptions NotificacaoOptions { get; set; }
}
