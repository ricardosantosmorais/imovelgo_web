using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class StateViewModel
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public StateViewModel()
        {
        }
    }
}
