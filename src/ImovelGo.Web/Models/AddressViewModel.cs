using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public int NeighborhoodId { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int PostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Main { get; set; }

        public CountryViewModel Country { get; set; }
        public NeighborhoodViewModel Neighborhood { get; set; }
        public StateViewModel State { get; set; }
        public CityViewModel City { get; set; }

        public string AddressWithCity
        {
            get
            {
                return String.Format("{0}, {1} - {2} - {3}", this.Street, this.Number, this.Neighborhood.Name, this.City.Name);
            }
        }

        public AddressViewModel()
        {
        }
    }
}
