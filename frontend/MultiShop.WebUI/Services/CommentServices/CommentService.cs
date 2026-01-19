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

        public async Task<List<ResultCommentDto>> CommentListByProductId(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>($"comments/CommentListByProductId/{id}");
        }
    }
}
