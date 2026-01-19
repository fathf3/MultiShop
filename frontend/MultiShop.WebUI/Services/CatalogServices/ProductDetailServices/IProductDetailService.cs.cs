using MultiShop.DtoLayer.Dtos.ProductDetailDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService : IGenericService<
       ResultProductDetailDto,
       CreateProductDetailDto,
       UpdateProductDetailDto>
    {
        Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
    }
}
