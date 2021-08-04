using System;

namespace GC_Movie_CRUD_Lab.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public ErrorViewModel(string ID)
        {
            RequestId = ID;
        }
    }
}
