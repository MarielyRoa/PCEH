using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PCEH.Application.DTOs
{
    public class ConsumeDto
    {
      
        public DateTime? Date { get; set; }

        public decimal Value { get; set; }
    }
}
