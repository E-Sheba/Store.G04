using Store.G04.Domain.DTOs.Products;
using Store.G04.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Domain.Service.Contracts
{
    public interface IProductService
    {
      public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public Task<IEnumerable<TypeBrandDTO>> GetAllTypesAsync();
        public Task<IEnumerable<TypeBrandDTO>> GetAllBrandsAsync();
        public Task<ProductDTO> GetProductByIdAsync(int id);
    }
}
