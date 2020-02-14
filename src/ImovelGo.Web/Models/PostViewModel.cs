using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public Guid PostId { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
        public string PhotoUrl { get; set; }
        public string Resume { get; set; }
        public int PageViews { get; set; }
        public DateTime DateAdd { get; set; }
        public string Tags { get; set; }
        public ValueObjectViewModel Category { get; set; }
        public List<PostCommentViewModel> Comemnts { get; set; }

        public string Date
        {
            get
            {
                return String.Format("{0} {1} {2}", DateAdd.Day, Helper.Helper.GetMonthName(DateAdd), DateAdd.Year);
            }
        }

        public PostViewModel()
        {
        }
    }
}
