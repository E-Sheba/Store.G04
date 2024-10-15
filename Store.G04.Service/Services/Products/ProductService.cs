using AutoMapper;
using Store.G04.Domain.DTOs.Products;
using Store.G04.Domain.Entities;
using Store.G04.Domain.Repository.Contracts;
using Store.G04.Domain.Service.Contracts;

namespace Store.G04.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //---------------------------------------------------------
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
            => _mapper.Map<IEnumerable<ProductDTO>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());


        //---------------------------------------------------------
        public async Task<IEnumerable<TypeBrandDTO>> GetAllTypesAsync()
           => _mapper.Map<IEnumerable<TypeBrandDTO>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());


        //---------------------------------------------------------
        public async Task<ProductDTO> GetProductByIdAsync(int id)
           => _mapper.Map<ProductDTO>(await _unitOfWork.Repository<Product, int>().GetAsync(id));


        //---------------------------------------------------------
        public async Task<IEnumerable<TypeBrandDTO>> GetAllBrandsAsync()
           => _mapper.Map<IEnumerable<TypeBrandDTO>>( await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());
        
        //---------------------------------------------------------
        




    }
}
