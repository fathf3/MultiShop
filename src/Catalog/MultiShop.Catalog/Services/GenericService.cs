using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services
{
    public abstract class GenericService<
      TEntity,
      TListDto,
      TCreateDto,
      TUpdateDto,
      TGetByIdDto>
      : IGenericService<TListDto, TCreateDto, TUpdateDto, TGetByIdDto>
      where TEntity : BaseEntity
    {
        protected readonly IMongoCollection<TEntity> _collection;
        protected readonly IMapper _mapper;

        protected GenericService(
            IMongoRepository<TEntity> repository,
            IMapper mapper)
        {
            _collection = repository.Collection;
            _mapper = mapper;
        }

        public virtual async Task<List<TListDto>> GetAllAsync()
        {
            var entities = await _collection
                .Find(FilterDefinition<TEntity>.Empty)
                .ToListAsync();

            return _mapper.Map<List<TListDto>>(entities);
        }

        public virtual async Task<TGetByIdDto> GetByIdAsync(string id)
        {
            var entity = await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<TGetByIdDto>(entity);
        }

        public virtual async Task CreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(TUpdateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _collection.ReplaceOneAsync(
                x => x.Id == entity.Id,
                entity);
        }

        public virtual async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }


}
