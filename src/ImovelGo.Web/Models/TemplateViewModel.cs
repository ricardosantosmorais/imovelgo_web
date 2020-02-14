using System;
namespace ImovelGo.Web.Models
{
    public class TemplateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Html { get; set; }
        public DateTime DateAdd { get; set; }
        public bool Enabled { get; set; }

        public TemplateViewModel()
        {
        }
    }
}
