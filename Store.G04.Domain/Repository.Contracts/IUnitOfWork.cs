using Store.G04.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Domain.Repository.Contracts
{
    public interface IUnitOfWork
    {
        public Task<int> CompleteAsync();

        #region Notes

        //there was a problem with the unit of work in the mvc model 
        //when we run the clr creates object of each repository even if we didn't want to use it
        // so this is Ineffecient but now we will write down some logic to overcome this problem

        #endregion

        //Create Repository<T> object and Return it 

       public IGenericRepository<TEntity,TKey> Repository<TEntity,TKey>() where TEntity : BaseEntity<TKey>;



    }
}
