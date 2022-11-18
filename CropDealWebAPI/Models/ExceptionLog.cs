using System;
using System.Collections.Generic;

namespace CropDealWebAPI.Models
{
    public partial class ExceptionLog
    {
        public int Id { get; set; }
        public string? ErrorCausedAt { get; set; }
        public string? DateTime { get; set; }
        public string? ErrorType { get; set; }
        public string? ErrorMessage { get; set; }
        public string? StackTrace { get; set; }
    }
}
