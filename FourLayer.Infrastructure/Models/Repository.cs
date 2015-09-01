using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Infrastructure.Models {
    public class Repository : IRepository {

        private DataContext _db;

        public Repository(DataContext db) {
            _db = db;
        }

        public IQueryable<T> Query<T>() where T : class {
            return _db.Set<T>().AsQueryable();
        }

        public T Find<T>(params object[] keyValues) where T : class {
            return _db.Set<T>().Find(keyValues);
        }

        public void Add<T>(T entity) where T : class {
            _db.Set<T>().Add(entity);
        }

        public void Delete<T>(params object[] keyValues) where T : class {
            _db.Set<T>().Remove(Find<T>(keyValues));
        }

        public void SaveChanges() {
            _db.SaveChanges();
        }

        public void Dispose() {
            _db.Dispose();
        }
    }

    public static class GenericRepositoryExtensions {
        public static IQueryable<T> Include<T, TProperty>(this IQueryable<T> queryable,
            Expression<Func<T, TProperty>> relatedEntity) where T : class {
            return System.Data.Entity.QueryableExtensions.Include<T, TProperty>(queryable, relatedEntity);
        }
    }
}
