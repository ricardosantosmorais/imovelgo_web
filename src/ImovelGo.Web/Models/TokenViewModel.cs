using System;

namespace ImovelGo.Web.Models
{
    public class TokenViewModel
    {
        public bool Authenticated { get; set; }
        public string accessToken { get; set; }
        public string Message { get; set; }

    }
}
