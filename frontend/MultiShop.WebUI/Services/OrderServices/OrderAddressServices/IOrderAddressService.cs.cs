using MultiShop.DtoLayer.Dtos.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
       
    }
}
