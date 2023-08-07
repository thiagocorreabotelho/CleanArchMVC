using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interface;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var returnCategoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(returnCategoryEntity);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var returnCategoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(returnCategoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var returnCategoryEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(returnCategoryEntity);
        }

        public async Task Remove(int id)
        {
            var returnCategoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Remove(returnCategoryEntity);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var returnCategoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(returnCategoryEntity);
        }
    }
}