using Microsoft.Extensions.DependencyInjection;
using MottuWebApplication.Application.Services;
using MottuWebApplication.Application.Interfaces;
using MottuWebApplication.Application.Interfaces.Repositories;
using MottuWebApplication.Infrastructure.Repositories;

namespace MottuWebApplication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositórios específicos
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IMotoRepository, MotoRepository>();
            services.AddScoped<IBairroRepository, BairroRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IFilialRepository, FilialRepository>();
            services.AddScoped<IFilialDepartamentoRepository, FilialDepartamentoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<ILogradouroRepository, LogradouroRepository>();
            services.AddScoped<IManutencaoRepository, ManutencaoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();

            // Serviços específicos
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IMotoService, MotoService>();
            services.AddScoped<IBairroService, BairroService>();
            services.AddScoped<ICidadeService, CidadeService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<IFilialService, FilialService>();
            services.AddScoped<IFilialDepartamentoService, FilialDepartamentoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<ILogradouroService, LogradouroService>();
            services.AddScoped<IManutencaoService, ManutencaoService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IPaisService, PaisService>();
            return services;
        }
    }
}
