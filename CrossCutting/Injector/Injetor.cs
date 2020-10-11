using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System;

namespace CrossCutting
{
    public class Injetor
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ILivroService, LivroService>();
        }
    }
}
