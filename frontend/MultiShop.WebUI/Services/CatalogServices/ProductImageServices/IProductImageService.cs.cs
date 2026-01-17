using MultiShop.DtoLayer.Dtos.ProductImageDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService : IGenericService<
        ResultProductImageDto,
        CreateProductImageDto,
        UpdateProductImageDto>
    {
    }
}
