using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.DTOs
{
    public class VariationDto
    {
        public int MonthIndex { get; set; }
        public decimal? VariationPercent { get; set; }
        public string Message { get; set; } = string.Empty;

    }
}
