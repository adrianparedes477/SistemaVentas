﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorio;
using SistemaVenta.DAL.Repositorio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.IOC
{
    public static class Dependencia

        //metodo de extencion
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbventaContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("CadenaSql"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();
        }

        
    }
}
