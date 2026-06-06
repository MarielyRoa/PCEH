using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.DTOs
{
    public class TrendDetectionDto
    {
        public int UpCount { get; set; }
        public int DownCount { get; set; }
        public int StableCount { get; set; }
        public string Trend { get; set; } = string.Empty;
    }
}
