using System;
namespace ImovelGo.Web.Models
{
    public class AccountViewModel
    {
        public Guid AccountId { get; set; }
        public int? CompanyId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Password { get; set; }
        public string DocumentNumber { get; set; }
        public int DDDCellPhone { get; set; }
        public string CellPhone { get; set; }
        public DateTime DateAdd { get; set; }
        public string accessToken { get; set; }

        public AccountViewModel()
        {
        }
    }
}
