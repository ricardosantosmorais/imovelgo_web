using System;
namespace ImovelGo.Web.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ReviewViewModel()
        {
        }
    }
}
