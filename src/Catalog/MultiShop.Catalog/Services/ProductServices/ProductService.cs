using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductServices;

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
            // 1️⃣ Ürünleri al
            var products = await _collection
                .Find(FilterDefinition<Product>.Empty)
                .ToListAsync();

            // 2️⃣ CategoryId’leri çıkar
            var categoryIds = products
                .Select(x => x.CategoryID)
                .Distinct()
                .ToList();

            // 3️⃣ CategoryService üzerinden TÜM kategorileri al
            var categories = await _categoryService.GetAllAsync();

            // 4️⃣ Sadece gerekli kategorileri filtrele
            var filteredCategories = categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToDictionary(c => c.Id, c => c.CategoryName);

            // 5️⃣ DTO oluştur
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
    }
}
