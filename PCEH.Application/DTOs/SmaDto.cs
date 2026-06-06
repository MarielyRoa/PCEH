using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.DTOs
{
    public class SmaDto
    {
        public decimal Average { get; set; }
        public decimal NextValue { get; set; }
        public string Trend { get; set; } = string.Empty;
    }
}
