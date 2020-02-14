using System;
namespace ImovelGo.Web.Models
{
    public class PostCommentViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public string Comment { get; set; }

        public PostCommentViewModel()
        {
        }
    }
}
