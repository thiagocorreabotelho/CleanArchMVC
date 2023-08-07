using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProducrRepository _producrRepository;
        private readonly IMapper _mapper;

        public ProductService(IProducrRepository producrRepository, IMapper mapper)
        {
            _producrRepository = producrRepository ??
              throw new ArgumentNullException(nameof(producrRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var returnProductEntity = await _producrRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(returnProductEntity);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var returnProductEntity = await _producrRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(returnProductEntity);
        }

        public async Task<ProductDTO> GetproductCategory(int id)
        {
            var returnProductEntity = await _producrRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(returnProductEntity);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var returnProductEntity = _mapper.Map<Product>(productDTO);
            await _producrRepository.CreateAsync(returnProductEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var returnProductEntity = _mapper.Map<Product>(productDTO);
            await _producrRepository.UpdateAsync(returnProductEntity);
        }

        public async Task Remove(int id)
        {
            var returnProductEntity = _producrRepository.GetByIdAsync(id).Result;
            await _producrRepository.RemoveAsync(returnProductEntity);
        }
    }
}