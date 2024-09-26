using Microsoft.Extensions.Logging; // Importa o namespace para logging

namespace MauiAppMinhasCompras
{
    public static class MauiProgram
    {
        // Método principal para criar a aplicação Maui
        public static MauiApp CreateMauiApp()
        {
            // Cria um construtor para a aplicação Maui
            var builder = MauiApp.CreateBuilder();
            
            // Configura a aplicação Maui
            builder
                .UseMauiApp<App>() // Define a classe App como a aplicação principal
                .ConfigureFonts(fonts => // Configura as fontes usadas na aplicação
                {
                    // Adiciona a fonte OpenSans-Regular com o alias "OpenSansRegular"
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    // Adiciona a fonte OpenSans-Semibold com o alias "OpenSansSemibold"
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // Adiciona suporte para logging de debug quando em modo de depuração
            builder.Logging.AddDebug();
#endif

            // Constrói e retorna a aplicação Maui configurada
            return builder.Build();
        }
    }
}
