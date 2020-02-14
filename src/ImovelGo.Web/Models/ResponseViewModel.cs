using System;

namespace ImovelGo.Web.Models
{
    public class ResponseViewModel<T>
    {
        public string RequestId { get; set; }
        public bool Success { get; set; }
        public T data { get; set; }
    }
}
