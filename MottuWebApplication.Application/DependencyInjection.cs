using Microsoft.Extensions.DependencyInjection;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Services;

namespace MottuWebApplication.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Serviços específicos registrados na camada de Infraestrutura para centralizar dependências.
            return services;
        }
    }
}
