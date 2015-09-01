using System;
using System.Linq;

namespace FourLayer.Infrastructure.Models {
    public interface IRepository : IDisposable {
        void Add<T>(T entity) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        IQueryable<T> Query<T>() where T : class;
        void SaveChanges();
    }
}