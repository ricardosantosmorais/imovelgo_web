using System;
using System.Collections.Generic;

namespace ImovelGo.Web.Models
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Html { get; set; }
        public string File { get; set; }
        public string FullPath { get; set; }
        public string Router { get; set; }
        public string Title { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool Enabled { get; set; }
        public bool HeaderMenu { get; set; }
        public List<AreaViewModel> Areas { get; set; }

        public PageViewModel()
        {
        }
    }
}
