using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductServices;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService
    : GenericService<
        Product,
        ResultProductDto,
        CreateProductDto,
        UpdateProductDto,
        GetByIdProductDto
        >,
      IProductService
    {
        private readonly ICategoryService _categoryService;
        public ProductService(
            IMongoRepository<Product> repository,
            IMapper mapper,ICategoryService categoryService)
            : base(repository, mapper)
        {
            _categoryService = categoryService;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            
            var products = await _collection
                .Find(FilterDefinition<Product>.Empty)
                .ToListAsync();

            
            var categoryIds = products
                .Select(x => x.CategoryID)
                .Distinct()
                .ToList();

            
            var categories = await _categoryService.GetAllAsync();

          
            var filteredCategories = categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToDictionary(c => c.Id, c => c.CategoryName);

            
            return products.Select(p => new ResultProductWithCategoryDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice,
                CategoryID = p.CategoryID,
                ProductDescription = p.ProductDescription,
                ProductImageUrl = p.ProductImageUrl,
                CategoryName = filteredCategories.TryGetValue(p.CategoryID, out var name)
                    ? name
                    : "Kategori Yok"
            }).ToList();
            
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByIdAsync(string categoryId)
        {
            var products = await _collection
                .Find(p => p.CategoryID == categoryId)
                .ToListAsync();

            var categotry = await _categoryService.GetByIdAsync(categoryId);
            var map = _mapper.Map<Category>(categotry);

            foreach (var item in products)
            {
                item.Category = map;
            }

            return _mapper.Map<List<ResultProductWithCategoryDto>>(products);
        }
    }
}
