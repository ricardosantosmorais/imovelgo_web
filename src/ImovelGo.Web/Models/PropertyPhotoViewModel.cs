using System;
namespace ImovelGo.Web.Models
{
    public class PropertyPhotoViewModel
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }

        public PropertyPhotoViewModel()
        {
        }
    }
}
