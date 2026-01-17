using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService : IGenericService<
       ResultCommentDto,
       CreateCommentDto,
       UpdateCommentDto>
    {
    }
}
