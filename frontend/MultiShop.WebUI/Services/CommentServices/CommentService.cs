using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService
  : GenericService<
      ResultCommentDto,
      CreateCommentDto,
      UpdateCommentDto>,
    ICommentService
    {
        public CommentService(HttpClient httpClient)
            : base(httpClient, "Comments")
        {
        }
    }
}
