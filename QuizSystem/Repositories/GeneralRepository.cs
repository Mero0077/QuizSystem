using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuizSystem.Data;
using QuizSystem.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace QuizSystem.Repositories
{
    public class GeneralRepository<T> where T : BaseModel
    {
        private ApplicationdbContext _context;
        private DbSet<T> _dbSet;

        public GeneralRepository()
        {
            _context = new ApplicationdbContext();
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where( e=>!e.IsDeleted);
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            var res = GetAll().Where(expression);
            return res;
        }
        public async Task<T> GetOne(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AsTracking().Where(expression).FirstOrDefaultAsync();
        }
        public async Task<T> GetOneById(int Id)
        {
            return await _dbSet.AsTracking().Where(e=>e.Id==Id).FirstOrDefaultAsync();
        }

        //public async Task<T?> GetOneExpression(Expression<Func<T, bool>>? filter = null)
        //{
        //    return await GetAllExpression(filter).FirstOrDefaultAsync();
        //}

        public async Task<T> Add (T entity)
        {
           await _dbSet.AddAsync(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public async Task<T> Update (T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void UpdateReflection(T entity, params string[] modifiedproperties) //modidified dh el7agat eli bs h3mlha update      
        {
            if (!_dbSet.Any(x => x.Id == entity.Id)) return; // if entity does not exist in dbset

            var local = _dbSet.Local.FirstOrDefault(e => e.Id == entity.Id);
            EntityEntry entityEntry;

            if (local == null)  // entity m4 m3molha tracking
            {
                entityEntry = _context.Entry(entity); // e3mlo tracking
            }
            else // lw m3molha tracking hatly metadata bta3tha
            {
                entityEntry = _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var property in entityEntry.Properties)
            {
                if (modifiedproperties.Contains(property.Metadata.Name)) // if values in modifiedarray exists in the metdata??
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;

                }
            }
            _context.SaveChanges();
        }

        public async Task<T> Delete(int Id)
        {
            var res= await GetOneById(Id);

            if (res != null || !res.IsDeleted)
            {
                res.IsDeleted = true;
                await _context.SaveChangesAsync();

            }
            return res;
        }

        public bool IsExists(int Id)
        {
           return GetOneById(Id) != null? true: false;
        }

    }
}
