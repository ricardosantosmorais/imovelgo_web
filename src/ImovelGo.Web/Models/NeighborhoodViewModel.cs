using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class NeighborhoodViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int? ZoneId { get; set; }

        public ZoneViewModel Zone { get; set; }

        public NeighborhoodViewModel()
        {
        }
    }
}
