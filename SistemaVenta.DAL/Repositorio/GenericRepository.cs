﻿using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DAL.Repositorio
{
    public class GenericRepository<TModelo>: IGenericRepository<TModelo> where TModelo : class
    {
        private readonly DbventaContext _dbContext;

        public GenericRepository(DbventaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _dbContext.Set<TModelo>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<bool> Eliminar(TModelo model)
        {
            try
            {
                _dbContext.Set<TModelo>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModelo> queryModelo = filtro == null ? _dbContext.Set<TModelo>()
                                    : _dbContext.Set<TModelo>().Where(filtro);
                return queryModelo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
