using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Linq.Expressions;
namespace DAL.Classes
{
    public class GenericActionsDB<T> : IGenericActionsDB<T> where T : class
    {
        private readonly CollegeDBContext _context;
        public GenericActionsDB(CollegeDBContext context)
        {
            _context = context;
        }
        public void Create(T obj)
        {
            if(obj == null)
                throw new ArgumentNullException(nameof(obj));
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }


        // פונקציה לעדכון שדה מסוים בישות
        public void Update<TKey>(TKey key, string columnName, object newValue)
        {
            var entity = Find<TKey>(key);
            var property = typeof(T).GetProperty(columnName);
            if (property == null)
                throw new ArgumentException($"Property '{columnName}' not found on {typeof(T).Name}");
            if (newValue != null && !property.PropertyType.IsAssignableFrom(newValue.GetType()))
                throw new ArgumentException($"Cannot assign value of type {newValue.GetType()} to property {property.Name} of type {property.PropertyType}");
            property.SetValue(entity, Convert.ChangeType(newValue, property.PropertyType));
            _context.Entry(entity).Property(columnName).IsModified = true;
            _context.SaveChanges();
        }

        public T Find<TKey>(TKey key)
        {
            var entity = _context.Set<T>().Find(key);
            if (entity == null)
                throw new ArgumentException($" '{key}' not found on the DB");
            return entity;
        }

        public void Delete<TKey>(TKey key)
        {
            var entity = Find<TKey>(key);
            if (entity == null)
                throw new ArgumentException($" '{key}' not found on the DB");
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}






























//public class GenericRepository<T> where T : class
//{
//private readonly CollegeDBContext _context;
//private readonly DbSet<T> _dbSet;

//public GenericRepository(CollegeDBContext context)
//{
//    _context = context;
//    _dbSet = context.Set<T>();
//}

//public  async Task AddAsync(T entity)
//{
//    await _dbSet.AddAsync(entity);
//    await _context.SaveChangesAsync();
//}

//public async Task<T> GetByIdAsync(int id)
//{
//    return await _dbSet.FindAsync(id);
//}

//public async Task<List<T>> GetAllAsync()
//{
//    return await _dbSet.ToListAsync();
//}

//public async Task DeleteAsync(T entity)
//{
//    _dbSet.Remove(entity);
//    await _context.SaveChangesAsync();
//}