using System;
namespace ImovelGo.Web.Models
{
    public class AreaViewModel
    {
		public int Id { get; set; }
		public int PageId { get; set; }
		public string Name { get; set; }
		public string Html { get; set; }
        public string File { get; set; }
        public string Path { get; set; }
        public int Position { get; set; }
        public DateTime DateAdd { get; set; }
		public DateTime DateUpdated { get; set; }
		public bool Enabled { get; set; }
		public bool Deleted { get; set; }

		public AreaViewModel()
        {
        }
    }
}
