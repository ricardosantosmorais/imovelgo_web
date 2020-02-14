using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public CityViewModel()
        {
        }
    }
}
