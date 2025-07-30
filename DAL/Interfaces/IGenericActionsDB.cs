using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericActionsDB<T> where T : class
    {
        void Create(T obj);
        T Find<TKey>(TKey key);
        void Delete<TKey>(TKey key);
        void Update<TKey>(TKey key, string columnName, object newValue);
    }
}
