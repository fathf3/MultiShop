namespace MultiShop.Catalog.Services
{
    public interface IGenericService<TListDto, TCreateDto, TUpdateDto, TGetByIdDto>
    {
        Task<List<TListDto>> GetAllAsync();
        Task<TGetByIdDto> GetByIdAsync(string id);
        Task CreateAsync(TCreateDto dto);
        Task UpdateAsync(TUpdateDto dto);
        Task DeleteAsync(string id);
    }
}
