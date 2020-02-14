using System;

namespace ImovelGo.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
