using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.DTOs
{
    public class PercentageVariationDto
    {
        public List<VariationDto> Variations { get; set; } = new();
        public decimal? AverageVariation { get; set; }
        public string Trend { get; set; } = string.Empty;
    }
}
