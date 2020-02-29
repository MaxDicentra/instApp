using System;

namespace instagram.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string MessageForUser{ get; set; }
    }
}
