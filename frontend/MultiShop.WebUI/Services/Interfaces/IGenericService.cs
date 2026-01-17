namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IGenericService<TResult, TCreate, TUpdate>
    {
        Task<List<TResult>> GetAllAsync();
        Task<TResult> GetByIdAsync(string id);
        Task CreateAsync(TCreate createDto);
        Task UpdateAsync(TUpdate updateDto);
        Task DeleteAsync(string id);
    }
}
