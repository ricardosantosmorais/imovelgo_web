using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class ZoneViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public ZoneViewModel()
        {
        }
    }
}
