using Store.G04.Domain.Entities;
using Store.G04.Domain.Repository.Contracts;
using Store.G04.Repository.Data.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var HashKey = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(HashKey))
            {

                var repository = new GenericRepository<TEntity, TKey>(_context);
                _repositories.Add(HashKey, repository);
            }
            return _repositories[HashKey] as IGenericRepository<TEntity,TKey>;

        }
    }
}
