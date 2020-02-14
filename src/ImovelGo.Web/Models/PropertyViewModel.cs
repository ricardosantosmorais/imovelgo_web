using System;
using System.Collections.Generic;
using System.Globalization;

namespace ImovelGo.Web.Models
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public int PropertyTypeId { get; set; }
        public int GoalId { get; set; }
        public int? BrokerId { get; set; }
        public int CompanyId { get; set; }
        public int StatusId { get; set; }
        public int AddressId { get; set; }
        public int Bedroom { get; set; }
        public int? SalePrice { get; set; }
        public int? RentPrice { get; set; }
        public int? Discount { get; set; }
        public int? TaxPrice { get; set; }
        public int? CondominiumPrice { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? Suite { get; set; }
        public int? BathRoom { get; set; }
        public int? Vacancies { get; set; }
        public string VideoUrl { get; set; }
        public double? UsefulAreaWidth { get; set; }
        public double? UsefulAreaDepth { get; set; }
        public double? TotalAreaWidth { get; set; }
        public double? TotalAreaDepth { get; set; }
        public double? PrivateAreaWidth { get; set; }
        public double? PrivateAreaDepth { get; set; }
        public bool IsNew { get; set; }
        public bool Featured { get; set; }
        public int PageViews { get; set; }
        public DateTime DateAdd { get; set; }
        public int? Floor { get; set; }
        public bool PetAccept { get; set; }
        public bool Furnished { get; set; }
        public bool NearMetro { get; set; }

        public ValueObjectViewModel PropertyType { get; set; }
        public AddressViewModel Address { get; set; }
        public BrokerViewModel Broker { get; set; }
        public List<PropertyPhotoViewModel> Photos { get; set; }

        public string Goal
        {
            get
            {
                return GoalId == 1 ? "Aluguel" : "Venda";
            }
        }

        public string FinalPrice
        {
            get
            {
                // Gets a NumberFormatInfo associated with the en-US culture.
                NumberFormatInfo nfi = new CultureInfo("pt-BR", false).NumberFormat;
                return GoalId == 1 ? RentPrice.Value.ToString("N", nfi) : SalePrice.Value.ToString("N", nfi);
            }
        }

        public PropertyViewModel()
        {
        }
    }
}
