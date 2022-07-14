using HotelScheduleRoom.Domain.Entity;
using HotelScheduleRoom.Domain.Interface;
using HotelScheduleRoom.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Infra
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEnt
    {
        private readonly HotelScheduleDbContext _context;
        private readonly DbSet<TEntity> _dbSet = null;
        private readonly ILogger<TEntity> _logger;

        public BaseRepository(HotelScheduleDbContext context, ILogger<TEntity>? logger)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _logger = logger;
        }
        public async Task<int> Delete(int id)
        {
            try
            {
                var obj = _dbSet.Find(id);
                _dbSet.Remove(obj);

                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogInformation(ex.Message);
            }
            return -1;
        }

        public async Task<int> Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogInformation(ex.Message);
            }
            return -1;
        }

        public async Task<int> Update(TEntity entity)
        {
            try
            {
                AttachUpdate(entity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogInformation(ex.Message);
            }

            return -1;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                var response = _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
                return await response;
            }
            catch(Exception ex)
            {
                this._logger.LogInformation(ex.Message);
            }
            return null;
        }

        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                var response = _context.Set<TEntity>();
                return await response.ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogInformation(ex.Message);
            }
            return null;
        }
        private TEntity AttachUpdate(TEntity entity)
        {
            var local = _dbSet.Local.FirstOrDefault(p => p.id == entity.id);

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

    }
}
